    [DataContract]
    public class GetSearchFilters_Results
    {
        public List<ElementList> ElementList{ get; set; }
        public List<Managers> ManagerList { get; set; }
        public GetSearchFilters_Results
        {
            ElementList = new List<ElementList>();
            ManagerList = new List<ManagerList>();
        }
        public GetSearchFilters_Results Execute()
        {
            this.ELementList = this.GetElementList();
            this.ManagerList = this.GetManagerList();
            return this;
        }
        public List<ElementList> GetElementList()
        {
            List<ElementList> list = new List<ElementList>();
            // Get list information from db 
            return list;
        }
        public List<ManagerList> GetManagerList()
        {
            List<ManagerList> list = new List<ManagerList>();
            // Get list information from db 
            return list;
        }
    }
