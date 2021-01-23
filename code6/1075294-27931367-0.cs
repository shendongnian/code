    class MyObject
    {
       public string OName { get; set; }
       public string OType { get; set; }
       public string Data { get; set; }
       public Object[] RelationList = new Object[5];
       public MyObject()
       {
          RelationList[0] = 1;
          RelationList[1] = 2;
       }
    }
