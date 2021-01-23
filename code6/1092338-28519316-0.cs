    // Example Model
    public class MyModel{
        public int Id {get; set;}
        public String Title {get; set;
    }
    List<MyModel> MyList = new List<MyModel>(){ new MyModel{ Id = 1, Title = "Jack"}};
    MyDataGridView.ItemSource = MyList;
