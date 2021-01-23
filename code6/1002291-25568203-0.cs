    string[] textdata = pagedata.Split("your split string");
    foreach (string stringforemail in textdata)
    {
        if (stringforemail.Contains("@") && stringforemail.Contains("."))
        {
            TableRow tr = new TableRow();
            //tr.BorderStyle = BorderStyle.Solid;
            TableCell tc = new TableCell();
            tc.BorderStyle = BorderStyle.Solid;
            tc.Text = stringforemail;
            tr.Cells.Add(tc);
            Table1.Rows.Add(tr);
        }
    }
