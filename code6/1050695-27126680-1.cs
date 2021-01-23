       [WebMethod]
    public static void SaveProjects(int DonatorId, List<Item> Items)
    {
        
        
    }
    
    public class Item
    {
        public int ClientId { get; set; }
        public List<CProject> CProject { get; set; }
        public List<Types> Types { get; set; }
    }
    public class CProject
    {
        public int ProjectId { get; set; }
        public int TypeId { get; set; }
    }
    public class Types
    {
        public int ProjectType { get; set; }
        public string ProjectName { get; set; }
    }
