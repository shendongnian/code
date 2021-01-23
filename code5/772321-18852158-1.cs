    struct process
    {
        public int Proc_Id;
        public int Proc_BurstTime;
        public int Proc_Priority;
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", Proc_Id, Proc_BurstTime, Proc_Priority);
        }
    };
