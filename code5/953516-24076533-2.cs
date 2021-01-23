    var stringsToCheck  = new string [] { "DisplayName", "SomethingElse", 
                                          "AndSomethingElse" };
    List<string> items = new List<string>();
    foreach(var s in stringsToCheck)
    {
         var val = sk.GetValue(s);
         if(val != null)
             items.Add(val.ToString());
    }
    var listViewItem = new ListViewItem(items.ToArray());
