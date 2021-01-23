    public class Project
    {
        public ICollection<Technician> Technicians { get; set; }
    }
    var project = new Project();
    project.Technicians = new List<Technician>()
    {
        new Technician(),
        new Technician()
    };
