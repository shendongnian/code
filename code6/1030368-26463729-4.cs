    System.Collections.Generic.List<int> selectedValues = new     System.Collections.Generic.List<int>();
    foreach (string s in words)
        if (!String.IsNullOrWhiteSpace(s))
            selectedValues.Add(Convert.ToInt32(s));
    string ids = String.Join(", ", selectedValues.Select(x => x.ToString()));
    string sql = String.Format("SELECT * FROM Table WHERE ID IN ({0})", ids);
