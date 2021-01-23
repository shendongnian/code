    public class AdminHomeViewModel
    {
        public AdminHomeViewModel()
        {
            Ongoing = new List<Project>();
            NYA = new List<Project>();
            Free = new List<Employee>();
        }
    
        public List<Project> Ongoing { get; set; } //table for ongoing projects
        public List<Project> NYA { get; set; } //another table for Not Yet Assigned projects
        public List<Employee> Free { get; set; } //another table for free employees
    }
