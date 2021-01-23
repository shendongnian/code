    class Class1
    {
        public string OName { get; set;}
        public string OType { get; set; }
        public string Data { get; set; }
        public object RelationList { get; set; }
    
        public Class1()
        {
          // initialize your properties here
          RelationList = new object[5];
          RelationList[0] = blabla;
          RelationList[1] = blabla;
        }
    }
