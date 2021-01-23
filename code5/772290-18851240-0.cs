    class UserInfo
    {
        public virtual int UserId{get;set;}
        public virtual string UserName{get;set;}
        public virtual IList<Task> Tasks{get;set;}
        public virtual Task ActiveTask
        {
            get
            {
                return Tasks.FirstOrDefault(t => t.IsActive == true);
            {
        }
        public void SetActive(Task task)
        {
            // Set all tasks to inactive
            // Set the task in question to active
        }
    }
