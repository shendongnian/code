    Random ran = new Random();
    var numbers = Enumerable.Range(1, 4).OrderBy(i => ran.Next()).ToList();
    
    List<ListItem> ans= new List<ListItem>();
    ans.Add(new ListItem(rsQuestion["a"].ToString(), "A"));
    ans.Add(new ListItem(rsQuestion["b"].ToString(), "B"));
    ans.Add(new ListItem(rsQuestion["c"].ToString(), "C"));
    ans.Add(new ListItem(rsQuestion["d"].ToString(), "D"));
    
    foreach (int num in numbers)
    {
        RadioButtonList1.Items.Add(ans[num - 1]);
    }
