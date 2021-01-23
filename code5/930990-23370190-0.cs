    Class MyObject
    {
        public string Name{get;set;}
        public string ID{get;set;}
    }
    
    MyObject[] MyObjectList = {new MyObject{Name="Terry",ID="122"}, new MyObject{Name="John",ID="234"},new MyObject{Name="Edvard",ID="665"}};
    
    for(int i=0;i<MyObjectList.Lenght, i++)
    ListBoxName.Items.Add(MyObjectList[i]);
