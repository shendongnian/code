        <Window x:Class="WpfApplication3.MainWindow"
                xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                Title="MainWindow" Height="350" Width="525" xmlns:my="clr-namespace:WpfApplication3">
            <Grid>
                <my:UserControl1  Background="Aqua"  Visibility="{Binding ChangeControlVisibility,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}" HorizontalAlignment="Left" Margin="111,66,0,0" x:Name="userControl11" VerticalAlignment="Top" Height="156" Width="195" />
                <Button Content="Button" Height="36" HorizontalAlignment="Left" Margin="36,18,0,0" Name="button1" VerticalAlignment="Top" Width="53"  Command="{Binding  MyButtonClickCommand}" />
            </Grid>
    
    </Window>
    
    
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;
    
    namespace WpfApplication3
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = new MyViewModel(); 
            }
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
    
            }
        }
    
        public class MyViewModel:INotifyPropertyChanged
        {
    
           public   MyViewModel()
            {
               _myCommand = new MyCommand(FuncToCall,FuncToEvaluate);
                
            }
            private ICommand _myCommand;  
            public ICommand MyButtonClickCommand
            {
                get {
                  
                    return _myCommand;  
                }
                set { _myCommand = value;  }
            }
    
            private void FuncToCall(object context)
            {
                //this is called when the button is clicked
                //for example
                if (this.ChangeControlVisibility== Visibility.Collapsed)
                {
                 this.ChangeControlVisibility = Visibility.Visible;   
                }
                else
                {
                  this.ChangeControlVisibility = Visibility.Collapsed;  
                }
                
            }
    
            private bool FuncToEvaluate(object context)
            {            
                return true;
            }
            Visibility _visibility =  Visibility.Visible;
            public Visibility ChangeControlVisibility
            {
                get { return _visibility; }
                set {
                     _visibility = value;
                     this.OnPropertyChanged("ChangeControlVisibility");
                }
    
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    
    
        class MyCommand: ICommand
        {
            public delegate void ICommandOnExecute(object parameter);
            public delegate bool ICommandOnCanExecute(object parameter);
            private ICommandOnExecute _execute;
    	    private ICommandOnCanExecute _canExecute;
    
            #region ICommand Members
    
            public bool CanExecute(object parameter)
            {
                return _canExecute.Invoke(parameter);
            }
            public MyCommand(ICommandOnExecute onExecuteMethod, ICommandOnCanExecute onCanExecuteMethod)
    	{
    		_execute = onExecuteMethod;
    		_canExecute = onCanExecuteMethod;
    	}
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
    
            public void Execute(object parameter)
            {
                _execute.Invoke(parameter);
            }
            #endregion
        }
    
    
    
        
    }
