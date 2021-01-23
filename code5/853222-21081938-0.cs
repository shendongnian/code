    DataTable dt = new DataTable();
    dt.Columns.Add("First Column", typeof(String));
    dt.Columns.Add("Second Column", typeof(Decimal));
    dt.Columns.Add("Third Column", typeof(bool));
    foreach (var i in Query)
    {
        List<Object> temp = new List<Object>();
        temp.Add(i.FirstValue);
        temp.Add(i.SecondValue);
        temp.Add(false);  // false => unchecked, true => checked.       
        dt.Rows.Add(temp.ToArray());
    }
