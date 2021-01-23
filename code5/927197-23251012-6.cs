    public class TData1
    {
        public String TText { get; set; }
        public String TValue { get; set; }
    }
    public class TData
    {
        public String TText { get; set; }
        public List<TData1> TValue { get; set; }
    }
     protected void Page_Load(object sender, EventArgs e)
        {
            List<TData1> lst = new List<TData1> 
            {
                new TData1 {TText = "JSON", TValue = "0"},
                new TData1 {TText = "C#", TValue = "1"},
                new TData1 {TText = "JAVA", TValue = "1"}
            };
            List<TData> Data = new List<TData>
            {
                new TData{TText = "JSON", TValue = lst},
                new TData{TText = "C#", TValue = lst},
                new TData{TText = "JAVA", TValue = lst}
            };
            this.Repeater1.DataSource = Data;
            this.Repeater1.DataBind();
        }
