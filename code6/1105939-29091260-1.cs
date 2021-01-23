     public ObservableCollection<MyClass > myVM= new ObservableCollection<MyClass>();
        
  
       public class Bindable:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
     public class MyClass : Bindable   {
          private string _Name;
          public string Name {
              get { return _Name; }
              set
              {
                  if (_Name != value)
                  {
                      _Name = value;                      
                      OnPropertyChanged();
                  }
              } 
          }
          private string _Surname;
          public string Surname
          {
              get { return _Surname; } 
              set{
                  if (_Surname != value)
                  {
                      _Surname = value;
                      OnPropertyChanged();
                  }
              }
          }
          public Visibility _IsVisible;
          public Visibility IsVisible {
              get { return _IsVisible; }
              set {
                  if (_IsVisible != value)
                  {
                      _IsVisible = value;
                      OnPropertyChanged();
                  }
              } 
          }
        }  
     
    
    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
      {
        foreach(MyClass item in itemsHolder.Items)
        {
           if(!item.Name.Contains((sender as TextBox).Text))
           {
               item.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
           }
           else
           {
               item.Visibility = Windows.UI.Xaml.Visibility.Visible;
           }
        }
      }
