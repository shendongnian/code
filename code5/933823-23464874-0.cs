    public class MyObject
    {
        public string Name { get; set; }
        public string Address { get; set; }
        //.......
    }
    //run this code in OnInit, public override OnInit(....)....
    private List<MyObject> Items = new List<MyObject>();
    MyObject mObj = new MyObject() { Name="Test", Address="SomeAddress" };
    dataGrid.DataSource = Items;
    dataGrid.DataBind();
