    public class RunningProcessComparer : IEqualityComparer<RunningProcess>
    {
        public bool Equals(RunningProcess x, RunningProcess y)
        {
            return x.ProcessID == y.ProcessID;
        }
        public string GetHashCode(RunningProcess obj)
        {
            return (string)obj.ProcessID;
        }
    }
