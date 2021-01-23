        public class MyViewModel : INotifyPropertyChanged
        {
           public Action CloseAction { get; set; }
           public ICommand MyCustomCommand { get; set; }
           
           public MyViewModel()
           {
              MyCustomCommand = new RelayCommand(new Action<object>(MyFunction));
           }
        
           private void MyFunction(object MyCommandParameter)
           {
            if (Convert.ToString(MyCommandParameter) == "True")
            {
                MessageBox.Show("Save Executed");
            }
            else
            {
                MessageBox.Show("Save Execcuted");
                CloseAction();
            }
        }
         
