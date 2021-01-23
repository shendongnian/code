    private AcadApplication acApp;
    private AcadDocument acDoc;
    private void btnRun_Click(object sender, EventArgs e)
    {
        if (acApp == null) return;
        acDoc = acApp.ActiveDocument;
        foreach (DataRow row in circleTable.Rows)
            DrawDatabaseCircle(row);
    }
    private void DrawDatabaseCircle(DataRow circRow)
    {
        var cmdFormat = string.Format("\"{0},{1}\" \"{2}\" \"{3}\" \"{4}\" \"{5}\"", circRow.ItemArray);
        acDoc.SendCommand(string.Format("(Command \"DRAWDBCIRCLE\" {0})\n", cmdFormat));
    }
