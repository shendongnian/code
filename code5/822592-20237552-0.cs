    var data = SomeContext.MyTable.Where(x => x.SomeField == someValue);
    if (someCondition) 
    {
      // Something like your 1st if clause
      data = data.Where(x => (x.SomeField2 != null && x.SomeField3 == "someText") || new[] { "001", "002" }.Contains(x.SomeField2));
    }
    
    var result = data.ToList();
