    public class DelegateCommand : ICommand
    {
         private Action<object> execute;
    
         public DelegateCommand(Action<object> executeMethod)
         {
              execute = executeMethod;
         }
    
         public bool CanExecute(object param)
         {
             return true;
         }
    
         public void Execute(object param)
         {
             execute(param);
         }
    }
