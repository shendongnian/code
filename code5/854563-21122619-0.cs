    protected void Page_Load(object sender, EventArgs e) {
        LoadTableDefs();
    }
    private void LoadTableDefs() {
        GridView1.Columns.Clear();
        if (/* condition 1 */) {
            TemplateField tf = new TemplateField();
            tf.HeaderTemplate = "foo";
            tf.ItemTemplate = new ItemTemplate();
            tf.EditItemTemplate = new EditItemTemplate();
            GridView1.Columns.Add(tf);
        } else if (/* condition 2 */) {
            TemplateField tf2 = new TemplateField();
            ...
            GridView1.Columns.Add(tf2);
        }
    }
