    private void button1_Click(object sender, EventArgs e)
    {
        Microsoft.Office.Interop.Access.Application acApp;
        this.Activate();
        acApp = (Microsoft.Office.Interop.Access.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Access.Application");
        Microsoft.Office.Interop.Access.Dao.Database cdb = acApp.CurrentDb();
        cdb.Execute("INSERT INTO LogTable (LogEntry) VALUES ('Entry added ' & Now())");
        acApp.Forms["LogForm"].Requery();
    }
