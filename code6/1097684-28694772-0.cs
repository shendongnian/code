    public class SampleProjectLoader : ICanLoadProject
    {
        private static SampleProjectLoader instance = new SampleProjectLoader();
        
        private SampleProjectLoader(){} 
        public static SampleProjectLoader Instance { get{ return instance; } }
 
        public void LoadProject(string token, string projectName)
        { /*Your implementation*/ }
    }
