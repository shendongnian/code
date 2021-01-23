    interface IGroup2
            {
                string SearchOption { get; set; }
                List<Projects> GetProjects();
            }
    
            public class GroupHead : IGroup2
            {
                public string SearchOption { get; set; }
    
                public GroupHead()
                {
                    SearchOption = "GroupHead";
                }
    
                public List<Projects> GetProjects()
                {   
                    //Code here
                    return null;
                }
            }
    
            public class ProjectIncharge : IGroup2
            {
                public string SearchOption { get; set; }
    
                public ProjectIncharge()
                {
                    SearchOption = "ProjectIncharge";
                }
    
                public List<Projects> GetProjects()
                {
                    //Code here
                    return null;
                }
            }
    
            public class ProjectManager : IGroup2
            {
                public string SearchOption { get; set; }
    
                public ProjectManager()
                {
                    SearchOption = "ProjectManager";
                }
    
                public List<Projects> GetProjects()
                {
                    //Code here
                    return null;
                }
            }
    
    public class Test
    {
            private static List<IGroup2> searchRuleList = new List<IGroup2>()
            {
              new GroupHead(),
              new ProjectIncharge(),
              new ProjectManager(),
            };
    
            public static void Main(string[] args)
            {
             IGroup2 searchOptionRule = searchRuleList.Find(delegate(IGroup2 searchRule) { return searchRule.SearchOption.Equals(args[0]); });
    
            } 
    }
