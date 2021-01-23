	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Threading;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Data;
	using System.Windows.Documents;
	using System.Windows.Input;
	using System.Windows.Media;
	using System.Windows.Media.Imaging;
	using System.Windows.Navigation;
	using System.Windows.Shapes;
	using System.ComponentModel;
	namespace SplashSxreenExample
	{
		/// <summary>
		/// Interaction logic for MainWindow.xaml
		/// </summary>
		public partial class MainWindow : Window, INotifyPropertyChanged
		{
			public event PropertyChangedEventHandler PropertyChanged; 
			private string _progressMessage;
			private int _progressValue;
			private BackgroundWorker _mWorker;
			public MainWindow()
			{
				InitializeComponent();
				_mWorker = new BackgroundWorker();
				_mWorker.WorkerReportsProgress = true; //Allow reporting
				_mWorker.ProgressChanged += _mWorker_ProgressChanged;
				_mWorker.DoWork += _mWorker_DoWork;
				_mWorker.RunWorkerAsync();
			}
			void _mWorker_DoWork(object sender, DoWorkEventArgs e)
			{
				BackgroundWorker wkr = sender as BackgroundWorker;
				wkr.ReportProgress(0, "Starting..."); //Reporting progress
				//Here do your stuff
				Thread.Sleep(500);
				wkr.ReportProgress(10, "Loading stuff...");
				//Here do your stuff
				Thread.Sleep(1000);
				wkr.ReportProgress(40, "Loading stuff 2...");
				//Here do your stuff
				Thread.Sleep(500);
				wkr.ReportProgress(80, "Loading stuff 3...");
				//Here do your stuff
				Thread.Sleep(1500);
				wkr.ReportProgress(90, "Loading stuff 4...");
				//Here do your stuff
				Thread.Sleep(2000);
				wkr.ReportProgress(100, "Finished");
			}
			void _mWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
			{
				ProgressValue = e.ProgressPercentage; //Value
				ProgressMessage = e.UserState.ToString(); //Message
			}
			#region Properties
			public string ProgressMessage
			{
				get { return _progressMessage; }
				set
				{
					_progressMessage = value;
					OnPropertyChanged("ProgressMessage");
				}
			}
			public int ProgressValue
			{
				get { return _progressValue; }
				set
				{
					_progressValue = value;
					OnPropertyChanged("ProgressValue");
				}
			}
			#endregion
			protected void OnPropertyChanged(string name)
			{
				PropertyChangedEventHandler handler = PropertyChanged;
				if (handler != null)
				{
					handler(this, new PropertyChangedEventArgs(name));
				}
			}
		}
	}
