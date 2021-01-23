    public class RunningProcessComparer : IEqualityComparer<RunningProcess>
    {
        public bool Equals(RunningProcess x, RunningProcess y)
        {
            return x.ProcessID == y.ProcessID;
        }
        public int GetHashCode(RunningProcess obj)
        {
            return obj.ProcessID.GetHashCode();
        }
    }
