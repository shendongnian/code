    public interface IProblem {
        void Solve();
        void CheckArguments();
    }
    public abstract class Problem : IProblem {
        public abstract void Solve();
        public void CheckArguments() {
            ...
        }
    }
    public class EasyProblem : Problem
    {
        public override void Solve()
        {
            ....
        }
    }
