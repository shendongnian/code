    public class MyObject
    {
        public string MyValue1 { get; set; }
        public string MyValue2 { get; set; }
    }
    
    var myList = new List<MyObject>();
    while(){
    //...
    myList.Add(new MyObject { MyValue1 = ds["myvalue1]", MyValue2 = ds["myvalue2"]});
    }
    
    My_Repeater.DataSource = myList;
    My_Repeater.DataBind();
