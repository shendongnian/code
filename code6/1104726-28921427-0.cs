public void ShowConnection(){
  var connvm = new ConnectionViewModel();
  //Does something with the connvm object, which allows 
  //continued process once dialog is closed.
  windowManager.ShowDialog(connvm, null,null);  
  if( connvm != null && connvm.Connected){
     ShowTables();
  }
}
