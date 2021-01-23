    using Behaviors;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    
    namespace ViewModels
    {
       class MainWindowViewModel : ObservableObject
       {
          public MainWindowViewModel()
          {
             CommandSwitchText = new RelayCommand( SwitchText );
          }
    
    
          public RelayCommand CommandSwitchText
          {
             get;
             private set;
          }
    
    
          private void SwitchText()
          {
             TextBoxScrollToEndBehavior.IsActive = true;
    
             string textTemp = Text1;
             Text1 = Text2;
             Text2 = textTemp;
    
             TextBoxScrollToEndBehavior.IsActive = false;
          }
    
    
          private string _text1 = "aaabbbcccd";
          public string Text1
          {
             get
             {
                return _text1;
             }
             set
             {
                _text1 = value;
                RaisePropertyChanged();
             }
          }
    
    
          private string _text2 = "aaaaabbbbbcccccd";
          public string Text2
          {
             get
             {
                return _text2;
             }
             set
             {
                _text2 = value;
                RaisePropertyChanged();
             }
          }
       }
    }
