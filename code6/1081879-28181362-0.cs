    enum CategoryOfWorkItem: int { C = 0, B, A };
    struct WorkItem : IComparer<WorkItem>
    {
        public CategoryOfWorkItem Category;
        public int Compare(WorkItem x, WorkItem y)
        {
            return x.Category - y.Category;
        }
        public void AddTo(List<WorkItem> list)
        {
            int i = list.BinarySearch(this, this);
            if (i < 0) i = ~i;
            list.Insert(i, this);
        }
    }
