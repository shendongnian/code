    protected void Page_Init(object sender, EventArgs e)
    {
        // TableRow -> TableCell ->Label
        var table = new Table();
        var row = new TableRow();
        var cell = new TableCell();
        var label = new Label();
        label.ID = "taskdocs_1";
        cell.Controls.Add(label);
        row.Cells.Add(cell);
        table.Rows.Add(row);
        tasksPlaceholder.Controls.Add(table);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Label docsLabel = (Label)tasksPlaceholder.FindControl("taskdocs_1");
        int index = tasksPlaceholder.Controls.IndexOf(docsLabel); 
        // docsLabel != null and index = -1 --> quod erat demonstrandum
    }
