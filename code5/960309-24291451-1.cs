    public class Getdata
    {
        public string Name { get; set; }
        public int TagID { get; set; }
        public string Address { get; set; }
    }
    [WebMethod]
    public List<GetData> GetValues()
    {
        var list = new List<GetData>();
        Getdata employee1= new Getdata()
        {
            Name="Sathya",
            TagID=10,
            Address="Chennai"
        };
        Getdata employee2= new Getdata()
        {
            Name="Ram",
            TagID=11,
            Address="Chennai"
        };
        Getdata employee3= new Getdata()
        {
            Name="Pandi",
            TagID=12,
            Address="Chennai"
        };
        Getdata employee4= new Getdata()
        {
            Name = "Karthick",
            TagID = 13,
            Address = "Chennai"
        };
        list.Add(employee1);
        list.Add(employee2);
        list.Add(employee3);
        list.Add(employee4);
        return list;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        EmployeeWebService obj = new EmployeeWebService ();
        var list = obj.GetValues();//Calling webmethod
        foreach (var item in list) 
        {
            Response.Write(item.Name + "<br>");
        }
    }
