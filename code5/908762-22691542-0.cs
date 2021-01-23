    DataTable dt = new DataTable();
    dt.Columns.Add("From", typeof (DateTime));
    dt.Columns.Add("To", typeof(DateTime));
    
    //first row is from list[0] to lst[1]
    dt.Rows.Add(lst[0], lst[1]);
    for (int i = 1; i < lst.Count-1; i++)
    {
    	//rows other than the first are (from lst[i] + one day) to (lst[i+1])
    	dt.Rows.Add(lst[i].AddDays(1), lst[i + 1]);
    }
