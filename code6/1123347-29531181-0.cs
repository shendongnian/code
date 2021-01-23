    public class Project : IEquatable<Project>
    {
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string Planner { get; set; }
        public DateTime ScheduleStart { get; set; }
        public DateTime ScheduleEnd { get; set; }
        public double EstimatedCost { get; set; }
        public double ActualCost { get; set; }
        public string AssignedTo { get; set; }
        public bool Equals(Project other)
        {
            bool flag = true;
            if (this.Name != other.Name)
                //--Do something
                flag = false;
            //TaskStatus otherTaskStatus = other.Status;
            //flag = other.Status.Equals(otherTaskStatus);//compare nested classes here
            return flag;
        }
    }
    public class TaskStatus : IEquatable<TaskStatus>
    {
        public bool Equals(TaskStatus other)
        {
            throw new NotImplementedException();
        }
    }
