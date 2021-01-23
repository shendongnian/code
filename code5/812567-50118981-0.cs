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
        public DepthSeededRequest(object request, object seed, int depth) : base(request, seed)
        {
            Depth = depth;
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
                int currentDepth = -1;
    
                var requestsForCurrentThread = this.GetMonitoredRequestsForCurrentThread();
                
                if (requestsForCurrentThread.Count > 0)
                {
                    currentDepth = requestsForCurrentThread.Max(x => x.Depth) + 1;
                }
    
                DepthSeededRequest depthResquest = new DepthSeededRequest(((SeededRequest)request).Request, ((SeededRequest)request).Seed, currentDepth);
    
                if (depthResquest.Depth >= this.GenerationDepth)
                {
                    return HandleGenerationDepthLimitRequest(request, depthResquest.Depth);
                }
    
                requestsForCurrentThread.Push(depthResquest);
                try
                {
                    return this.Builder.Create(request, context);
                }
                finally
                {
                    requestsForCurrentThread.Pop();
                }
            }
            else
            {
                return this.Builder.Create(request, context);
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
