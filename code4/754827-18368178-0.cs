    public class BusinessName {
        public string Name { get; set; }
        public string Type { get; set; }
    }
    void Main()
    {
    	List<BusinessName> businessNames = new List<BusinessName>();
    	List<string> names = new List<string>();
    	names=names.Concat(businessNames.Select(b=>b.Name)).ToList();
    }
