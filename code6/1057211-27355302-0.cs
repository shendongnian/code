    foreach (DataRow r in currentAttribs.Rows)
    {
        foreach (Object obj in r.ItemArray)
        {
              string tableRow = string.Format("<TR><TD>{0}</TD></TR>", r[0]);
              Literal lc = new Literal();
              lc.Text = tableRow;
              divFeatureInfo.Controls.Add(lc);
              // do whatever you need to do with obj
        }
    }
