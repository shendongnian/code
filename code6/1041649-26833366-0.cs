    public class ActorsViewModel
    {
        public ActorsViewModel(){} //Default ctor for modelbinder and co
        public ActorsViewModel(string projectName)
        {
            ProjectName = projectName;
        }
        public string ProjectName {get; }
        public List<Actor> ProjectActors {get; set;}
    }
