    public class MyCommand : ICommand
    {
      private bool _CanExecute = true;
      public bool CanExecute(object parameter)
      {
         
        return _CanExecute;
      }
   
      public void Execute(object parameter)
      {
        if(parameter!=null){
          _CanExecute = false;
              //do your thing here....
         _CanExecute = true; 
       }
    }
