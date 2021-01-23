    using System.Windows.Input;
    using ReactiveUIListBox.Model;
    using SecretSauce.Mvvm.ViewModelBase;
    
    namespace ReactiveUIListBox.ViewModel
    {
    	public class MainWindowViewModel : ViewModelBase
    	{
    		public MainWindowViewModel()
    		{
    			Model = new ReactiveModel<string>();
    		}
    		public ReactiveModel<string> Model
    		{
    			get;
    			set;
    		}
    
    		public ICommand TestCommand
    		{
    			get { return new RelayCommand(ExecuteTestCommand); }
    		}
    
    		private void ExecuteTestCommand(object obj)
    		{
    			Model.TestReactiveList.Add("test string");
    		}
    	}
    }
