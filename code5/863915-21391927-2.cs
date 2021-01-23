    public struct WorkOrderConcretized
    {
        public string Title { get; set; }
        public PersonConcretized CreatedBy { get; set; }
        public WorkOrderConcretized(WorkOrder w)
        {
            this.Title = w.Title;
            this.CreatedBy = new PersonConcretized(w.CreatedBy);
        }
    }
