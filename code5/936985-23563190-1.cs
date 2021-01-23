    public class main()
    {
        public void main()
        {
            JObject jo = new JObject();
            jo = functionthatretrievestheJSONdata();
    
            Results dt1 = JsonConvert.DeserializeObject<Results>(jo.ToString());
            var depts = dt1.Value;
        }
    }
    
    public class Results 
    {
        public bool Successful {get;set;}
        public List<Department> Value {get;set;}
    }
    public class Department
    {
        public int no { get; set; }
        public string name { get; set; }
    }
