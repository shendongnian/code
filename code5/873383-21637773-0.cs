    public void Question()
    {
      //Is there going to be a problem using `this` in the predicate
      var issue = context.SomeTable.Where(st => st.ForeignKeyId == PrivateId);
    }
