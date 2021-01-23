    void Main()
    {
        Observable.Merge(
            RunnerFactory().Select(x => x.Run(null).ToObservable()
            .Timeout(TimeSpan.FromSeconds(1), Observable.Return(true))))
            .Where(res => !res)
            .Any().Select(res => !res)
            .Subscribe(
                res => Console.WriteLine("Result: " + res),
                ex => Console.WriteLine("Error: " + ex.Message));										 	
    }
    public IEnumerable<IRunner> RunnerFactory()
    {
        yield return new FalseRunner();
        yield return new SlowRunner();
        yield return new TrueRunner();
    }
    public interface IRunner
    {
        Task<bool> Run(object o);
    }
    public class Runner : IRunner
    {
        protected bool _outcome;
        public Runner(bool outcome)
        {
            _outcome = outcome;
        }
        public virtual async Task<bool> Run(object o)
        {
            var result = await Task<bool>.Factory.StartNew(() => _outcome);		
            return result;
        }
    }
    public class TrueRunner : Runner
    {
        public TrueRunner() : base(true) {}
    }	
    public class FalseRunner : Runner
    {
        public FalseRunner() : base(false) {}
    }	
    public class SlowRunner : Runner
    {
        public SlowRunner() : base(false) {}
	
        public override async Task<bool> Run(object o)
        {
            var result = await Task<bool>.Factory.StartNew(
                () => { Thread.Sleep(5000); return _outcome; });		
            return result;
        }
    }	
