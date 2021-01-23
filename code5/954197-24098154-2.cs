	using System;
	using System.Collections.ObjectModel;
	using System.Threading;
	using System.Windows;
	using System.Windows.Data;
	namespace MultipleDataGrid
	{
		public class Something
		{
			public static void Start()
			{
				var connectionThread = new Thread(StartListening);
				Log = new ObservableCollection<string>();
				BindingOperations.EnableCollectionSynchronization(Log, _lock);//For Thread Safety
				connectionThread.IsBackground = true;
				connectionThread.Start();
			}
			public static ObservableCollection<string> Log { get; private set; }
			private static readonly object _lock = new object();
			private static void StartListening()
			{
				try
				{
					int i = 0;
					while (i <= 100)
					{
						Log.Add("Something happened " + i);
						Thread.Sleep(1000);
						i++;
					}
				}
				catch (Exception)
				{
					// temp
					MessageBox.Show("Error in PacketHandler class");
				}
			}
		}
	}
