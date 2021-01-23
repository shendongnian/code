    class TickColumn : ITemplate
        {
    private String _label;
            public TickColumn(String p_label)
            {
                this._label = p_label;
            }
            public void InstantiateIn(System.Web.UI.Control container)
            {
                CheckBox cbAll = new CheckBox();
                cbAll.ID = "cbAll";
                cbAll.Text = this._label;
                container.Controls.Add(cbAll);
            }
       }
