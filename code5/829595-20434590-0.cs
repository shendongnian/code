    public List<T> ListTest(MyRequest request, IEnumerable<T> mylist)
    {
      var stuff = GetStuff(request);
      var noNullList = mylist.AsQueryable().Where(item => item != null);  // <-- Error
      return noNullList;
    }
