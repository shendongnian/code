    string str = "One,Two;Three,Four;Five,Six";
    DataTable dt = new DataTable();
    dt.Columns.Add("Col1", typeof(string));
    dt.Columns.Add("Col2", typeof(string));
    str.Split(';').ForEach(r => dt.LoadDataRow(
                                    r.Split(',').Select(t => (object)t).ToArray()
                                    , LoadOption.OverwriteChanges));
