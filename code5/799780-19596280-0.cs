    public void AddLog(Exception ex) {
       Log newLog = new Log(ex.Message, ex.InnerException);
       singleton._logs.Add(newLog);
       var dt = (DataTable)frm.myGrid.DataSource;
       dt.Rows.Add(newLog.Time, newLog.Err, newLog.Ex.Message);
    }
    public void AddLog(string text) {
       Log newLog = new Log(text);
       singleton._logs.Add(newLog);
       var dt = (DataTable)frm.myGrid.DataSource;
       dt.Rows.Add(newLog.Time, newLog.Err, newLog.Ex.Message);
    }
