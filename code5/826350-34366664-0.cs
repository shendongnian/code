    PlaceHolder ph = new PlaceHolder();
    ph.Controls.Add(new LiteralControl("<tr><td>"));
    ph.Controls.Add(new LiteralControl(DataBinder.Eval(item.DataItem, "Name") as string));
    ph.Controls.Add(new LiteralControl("</td></tr>"));
    item.Controls.Add(ph);
