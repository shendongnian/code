    public class LazyComputationCoreAlphaProxy : IComputationCoreAlpha
    {
        public int RunComputation(int myParam) {    
    		var heavyWeight = DependencyResolver.GetInstance<IComputationCoreAlpha>();
            return heavyWeight.RunComputation(myParam);
        }
    }
