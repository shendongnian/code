    class MyCompare : IComparer<MyObject>
    {
      public int Compare(x1, x2)
      {
          if (x1.parent == parent1 && x2.parent == parent2)
            return 1;
          if (x1.parent == x2.parent)
            return 0;
          //ect 
      }
    }
    List<MyObject> list = GetWeirdObjects();
    list.Sort(new MyCompare());
 
