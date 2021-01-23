public void ShowConnection(){
  var connvm = new ConnectionViewModel();
   IDictionary<string, object> settings = new Dictionary<string, object>();
            settings["WindowStartupLocation"] = WindowStartupLocation.CenterScreen;
  //Does something with the connvm object, which allows 
  //continued process once dialog is closed.
  windowManager.ShowDialog(connvm, null,settings);  
  if( connvm != null && connvm.Connected){
     ShowTables();
  }
}
