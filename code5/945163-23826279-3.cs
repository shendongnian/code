		public partial class MainWindow : Window
		{
			public MainWindow()
			{
				this.DataContext = new Datas();
				this.InitializeComponent();
			}
		}
		public class Datas
		{
			private ObservableCollection<String> titles;
			public ObservableCollection<String> Titles
			{
				get
				{
					if (this.titles == null)
					{
						this.titles = new ObservableCollection<String>()
						{
							"Title 1",
							"Title 2",
							"Title 3",
							"Title 4"
						};
					}
					return this.titles;
				}
			}
		}
