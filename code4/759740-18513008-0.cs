    class MyViewModel
    {
        public string TypeName {get; set; }
        public string Id {get; set; }
    }
    // generate the datasource list.
    List<MyViewModel> list = new List<MyViewModel>();
    list.Add(new MyViewModel(){ Id = 1, TypeName = typeof(int).Name});
    list.Add(new MyViewModel(){ Id = 2, TypeName = typeof(string).Name});
    
    // how i must to config displayMember
    myComboBox.DisplayMember = "TypeName";
    myComboBox.ValueMember = "Id";
    myComboBox.DataSoutce = list;
