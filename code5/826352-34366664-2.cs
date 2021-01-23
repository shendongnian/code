    public class ItemTemplate : ITemplate
    {
        public void InstantiateIn(Control container)
        {
            ListViewItem item = (ListViewItem)container;
            LiteralControl itemMarkup =
                new LiteralControl("<tr><td>"
                                    + (DataBinder.Eval(item.DataItem, "Name") as string)
                                    + "</td></tr>");
            item.Controls.Add(itemMarkup);
        }
    }
