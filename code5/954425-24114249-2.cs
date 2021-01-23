	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Windows;
	using System.Windows.Data;
	namespace MultipleDataGrid
	{
		public class ViewModel : INotifyPropertyChanged
		{
			private static readonly object _lockOne = new object();
			private static readonly object _lockTwo = new object();
			private Dictionary<string, string> _sourceOne;
			public Dictionary<string, string> SourceOne
			{
				get { return _sourceOne; }
			}
			private Dictionary<string, string> _sourceTwo;
			public Dictionary<string, string> SourceTwo
			{
				get { return _sourceTwo; }
			}
			public ViewModel()
			{
				_sourceOne = new Dictionary<string, string>();
				_sourceTwo = new Dictionary<string, string>();
				BindingOperations.EnableCollectionSynchronization(_sourceOne, _lockOne); //Thread safety
				BindingOperations.EnableCollectionSynchronization(_sourceTwo, _lockTwo); //Thread safety
				//To delay the addition of the items to the dictionary and then raise a property changed at last after the task is executed
				Task.Run(async () => await LoadDictionary()).ContinueWith(t =>
					{
						MessageBox.Show("Task Ran");
						if (t.IsCompleted)
						{
							RaisePropertyChanged("SourceOne");
							RaisePropertyChanged("SourceTwo");
						}
					});
			}
			private async Task LoadDictionary()
			{
				Thread.Sleep(5000);
				await Task.Run(() =>
				{
					_sourceOne.Add("KeyOneOne", "ValueOne");
					_sourceOne.Add("KeyOneTwo", "ValueTwo");
					_sourceOne.Add("KeyOneThree", "ValueThree");
					_sourceOne.Add("KeyOneFour", "ValueFour");
					_sourceOne.Add("KeyOneFive", "ValueFive");
				});
				await Task.Run(() =>
				{
					_sourceTwo.Add("KeyTwoOne", "ValueOne");
					_sourceTwo.Add("KeyTwoTwo", "ValueTwo");
					_sourceTwo.Add("KeyTwoThree", "ValueThree");
					_sourceTwo.Add("KeyTwoFour", "ValueFour");
					_sourceTwo.Add("KeyTwoFive", "ValueFive");
				});
			}
			public event PropertyChangedEventHandler PropertyChanged;
			public void RaisePropertyChanged(string propName)
			{
				var pc = PropertyChanged;
				if (pc != null)
					pc(this, new PropertyChangedEventArgs(propName));
			}
		}
	}
