    String[] firtNames = new String[] { "abc", "def", "ghi", "jkl" };
    String[] lastNames = new String[] { "mno", "pqr", "stu", "vwx" };
    String[] userNames = new String[] { "gb", "aa", "ss", "am" };
    String[] actions = new String[] { "Get", "Set", "Submit", "Get", "Set", "Submit","Get","Set", "Submit", "Get", "Set", "Submit" };
            
    Int32 counter = 31;
     var p = firtNames.Select((col, index) => new { FirstName = col, LastName = lastNames[index], UserName = userNames [index] , a1 = actions[index * counter], a2 = actions[index * counter + 1],..., a31 = actions[index * counter + 30] }).ToList();
            ListView1.DataSource = p;
            ListView1.DataBind();
