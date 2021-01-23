    public class GenerationDepthBehavior : ISpecimenBuilderTransformation
    {
        private const int DefaultGenerationDepth = 1;
        private readonly int generationDepth;
        public GenerationDepthBehavior() : this(DefaultGenerationDepth)
        {
        }
        public GenerationDepthBehavior(int generationDepth)
        {
            if (generationDepth < 1)
                throw new ArgumentOutOfRangeException(nameof(generationDepth), "Generation depth must be greater than 0.");
            this.generationDepth = generationDepth;
        }
        public ISpecimenBuilderNode Transform(ISpecimenBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            return new GenerationDepthGuard(builder, new GenerationDepthHandler(), this.generationDepth);
        }
    }
    public interface IGenerationDepthHandler
    {
        object HandleGenerationDepthLimitRequest(object request, IEnumerable<object> recordedRequests, int depth);
    }
    public class DepthSeededRequest : SeededRequest
    {
        public int Depth { get; }
        public int MaxDepth { get; set; }
        public bool ContinueSeed { get; }
        public int GenerationLevel { get; private set; }
        public DepthSeededRequest(object request, object seed, int depth) : base(request, seed)
        {
            Depth = depth;
            Type innerRequest = request as Type;
            if (innerRequest != null)
            {
                bool nullable = Nullable.GetUnderlyingType(innerRequest) != null;
                ContinueSeed = nullable || innerRequest.IsGenericType;
                if (ContinueSeed)
                {
                    GenerationLevel = GetGenerationLevel(innerRequest);
                }
            }
        }
        private int GetGenerationLevel(Type innerRequest)
        {
            int level = 0;
            if (Nullable.GetUnderlyingType(innerRequest) != null)
            {
                level = 1;
            }
            if (innerRequest.IsGenericType)
            {
                foreach (Type generic in innerRequest.GetGenericArguments())
                {
                    level++;
                    level += GetGenerationLevel(generic);
                }
            }
            return level;
        }
    }
    public class GenerationDepthGuard : ISpecimenBuilderNode
    {
        private readonly ThreadLocal<Stack<DepthSeededRequest>> requestsByThread
            = new ThreadLocal<Stack<DepthSeededRequest>>(() => new Stack<DepthSeededRequest>());
        private Stack<DepthSeededRequest> GetMonitoredRequestsForCurrentThread() => this.requestsByThread.Value;
        public GenerationDepthGuard(ISpecimenBuilder builder)
            : this(builder, EqualityComparer<object>.Default)
        {
        }
        public GenerationDepthGuard(
            ISpecimenBuilder builder,
            IGenerationDepthHandler depthHandler)
            : this(
                builder,
                depthHandler,
                EqualityComparer<object>.Default,
                1)
        {
        }
        public GenerationDepthGuard(
            ISpecimenBuilder builder,
            IGenerationDepthHandler depthHandler,
            int generationDepth)
            : this(
                builder,
                depthHandler,
                EqualityComparer<object>.Default,
                generationDepth)
        {
        }
        public GenerationDepthGuard(ISpecimenBuilder builder, IEqualityComparer comparer)
        {
            this.Builder = builder ?? throw new ArgumentNullException(nameof(builder));
            this.Comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
            this.GenerationDepth = 1;
        }
        public GenerationDepthGuard(
            ISpecimenBuilder builder,
            IGenerationDepthHandler depthHandler,
            IEqualityComparer comparer)
            : this(
            builder,
            depthHandler,
            comparer,
            1)
        {
        }
        public GenerationDepthGuard(
            ISpecimenBuilder builder,
            IGenerationDepthHandler depthHandler,
            IEqualityComparer comparer,
            int generationDepth)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            if (depthHandler == null) throw new ArgumentNullException(nameof(depthHandler));
            if (comparer == null) throw new ArgumentNullException(nameof(comparer));
            if (generationDepth < 1)
                throw new ArgumentOutOfRangeException(nameof(generationDepth), "Generation depth must be greater than 0.");
            this.Builder = builder;
            this.GenerationDepthHandler = depthHandler;
            this.Comparer = comparer;
            this.GenerationDepth = generationDepth;
        }
        public ISpecimenBuilder Builder { get; }
        public IGenerationDepthHandler GenerationDepthHandler { get; }
        public int GenerationDepth { get; }
        public int CurrentDepth { get; }
        public IEqualityComparer Comparer { get; }
        protected IEnumerable RecordedRequests => this.GetMonitoredRequestsForCurrentThread();
        public virtual object HandleGenerationDepthLimitRequest(object request, int currentDepth)
        {
            return this.GenerationDepthHandler.HandleGenerationDepthLimitRequest(
                request,
                this.GetMonitoredRequestsForCurrentThread(), currentDepth);
        }
        public object Create(object request, ISpecimenContext context)
        {
            if (request is SeededRequest)
            {
                int currentDepth = 0;
                var requestsForCurrentThread = GetMonitoredRequestsForCurrentThread();
                if (requestsForCurrentThread.Count > 0)
                {
                    currentDepth = requestsForCurrentThread.Max(x => x.Depth) + 1;
                }
                DepthSeededRequest depthRequest = new DepthSeededRequest(((SeededRequest)request).Request, ((SeededRequest)request).Seed, currentDepth);
                if (depthRequest.Depth >= GenerationDepth)
                {
                    var parentRequest = requestsForCurrentThread.Peek();
                    depthRequest.MaxDepth = parentRequest.Depth + parentRequest.GenerationLevel;
                    if (!(parentRequest.ContinueSeed && currentDepth < depthRequest.MaxDepth))
                    {
                        return HandleGenerationDepthLimitRequest(request, depthRequest.Depth);
                    }
                }
                requestsForCurrentThread.Push(depthRequest);
                try
                {
                    return Builder.Create(request, context);
                }
                finally
                {
                    requestsForCurrentThread.Pop();
                }
            }
            else
            {
                return Builder.Create(request, context);
            }
        }
        public virtual ISpecimenBuilderNode Compose(
            IEnumerable<ISpecimenBuilder> builders)
        {
            var composedBuilder = ComposeIfMultiple(
                builders);
            return new GenerationDepthGuard(
                composedBuilder,
                this.GenerationDepthHandler,
                this.Comparer,
                this.GenerationDepth);
        }
        internal static ISpecimenBuilder ComposeIfMultiple(IEnumerable<ISpecimenBuilder> builders)
        {
            ISpecimenBuilder singleItem = null;
            List<ISpecimenBuilder> multipleItems = null;
            bool hasItems = false;
            using (var enumerator = builders.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    singleItem = enumerator.Current;
                    hasItems = true;
                    while (enumerator.MoveNext())
                    {
                        if (multipleItems == null)
                        {
                            multipleItems = new List<ISpecimenBuilder> { singleItem };
                        }
                        multipleItems.Add(enumerator.Current);
                    }
                }
            }
            if (!hasItems)
            {
                return new CompositeSpecimenBuilder();
            }
            if (multipleItems == null)
            {
                return singleItem;
            }
            return new CompositeSpecimenBuilder(multipleItems);
        }
        public virtual IEnumerator<ISpecimenBuilder> GetEnumerator()
        {
            yield return this.Builder;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
    public class GenerationDepthHandler : IGenerationDepthHandler
    {
        public object HandleGenerationDepthLimitRequest(
            object request,
            IEnumerable<object> recordedRequests, int depth)
        {
            return new OmitSpecimen();
        }
    }
