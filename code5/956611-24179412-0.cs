    public class ViewModel
    {
       public RelayCommand<object> CloseWindowCommand {get; private set;}
       
       public ViewModel()
       {
          CloseWindowCommand = new RelayCommand<object>(CloseTheWindow);
       }
       
       private void CloseWindow(object obj)
       {
          var window = obj as Window;
          if(window != null) 
             window.Close();
       }
    }
