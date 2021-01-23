    public class CustomClass
        {
            public string GroupName { get; set; }
            public int GroupID { get; set; }
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            List<CustomClass> list = new List<CustomClass>();
            foreach (var x in list) {
                Console.WriteLine(x.GroupName);
            }
    
        }
