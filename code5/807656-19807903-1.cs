    public abstract class Problem {
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
    ...
    static Main(string[] args)
    {
        List<Problem> problemsToSolve = ...
        foreach(var problem in problemsToSolve)
        {
            problem.CheckArguments();
            problem.Solve();
        }
    }    
