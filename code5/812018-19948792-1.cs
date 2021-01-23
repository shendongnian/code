    public class MyModel
    {
      public string User {get;set;}
      public SqlConnection Connection {get;set;}
    }
    public class ViewModel : INotifyPropertyChanged
    {
      private MyModel _model = new MyModel();
      public string Server
      {
        get { return _model.Connection.DataSource; }
        set 
        { 
          _model.Connection.DataSource= value;
          OnPropertyChanged("Server");
        }
      }
      public string User 
      {
        get { return _model.User; }
        set 
        { 
          _model.User = value;
          OnPropertyChanged("User");
        }
      }
      public string Password
      {
        set { _model.Connection.Credential = new Credential(_model.user, value); }
      }
     // Syntax varies depending on which MVVM library you are using
     public XXXXCommand ConnectCommand 
     { 
       get 
       { 
         return new XXXXCommand(
           canExecute => !Connection.IsConnected,
           () => Connection.Connect()
        );
      }
    }
