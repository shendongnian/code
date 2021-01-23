        public class MyViewModel : INotifyPropertyChanged
        {
           public Action CloseAction { get; set; }
           public ICommand MyCustomCommand { get; set; }
           
           public MyViewModel()
           {
              MyCustomCommand = new RelayCommand(new Action<object>(MyFunction));
           }
        
           private void MyFunction(object obj)
           {
              MessageBox.Show("Save Execcuted"); // Do your stuff...
              CloseAction();
           }
         }
