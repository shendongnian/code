    public class ProjectTypeModel
    {
        public string Name { get; set; }
    }
    public class TestModel
    {
        public IList<ProjectTypeModel> Types { get; set; }
    }
