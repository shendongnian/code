    public void Setup()
    {
      Class1List list1 = new Class1List();
      var query = from x in BaseClassList
            where x.GetType() == typeof(Class1)
            select x;
       foreach(var item in query){
          var temp = item as Class1;
          if(temp  != null)
             list1.Add(temp);
       }
    }
