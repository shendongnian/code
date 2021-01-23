    class YourForm
    {
     void someMethod()
     {
      MyDatabase myDatabase = new MyDatabase();
      myDatabase.ds = //do something..
      gridView.DataSource = myDatabase.ds; //using the variable..
     }
    }
