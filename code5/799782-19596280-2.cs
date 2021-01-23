    public delegate void AddNewLogEventHandler(object sender, AddNewLogEventArgs e);   
    public event AddNewLogEventHandler AddNewLog;
    public class AddNewLogEventArgs : EventArgs {
      public Log {get; private set;}
      public AddNewLogEventArgs(Log log){
        Log = log;
      }
    }
    protected virtual void OnAddNewLog(AddNewLogEventArgs e){
      AddNewLogEventHandler handler = AddNewLog;
      if(handler != null) handler(this, e);
    }
    public void AddLog(Exception ex) {
       Log newLog = new Log(ex.Message, ex.InnerException);
       singleton._logs.Add(newLog);       
       OnAddNewLog(new AddNewLogEventArgs(newLog));
    }
    public void AddLog(string text) {
       Log newLog = new Log(text);
       singleton._logs.Add(newLog);
       OnAddNewLog(new AddNewLogEventArgs(newLog));
    }
