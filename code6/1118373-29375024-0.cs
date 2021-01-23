	namespace SOBindingTest1
	{
		public partial class MainWindow : Window
		{
			public ClientRatesViewModel crvm { get; set; }
			public MainWindow()
			{
				InitializeComponent();
				crvm = new ClientRatesViewModel();
			}
			private void cboTest_SelectionChanged(object sender, SelectionChangedEventArgs e)
			{
				if (e.AddedItems != null && e.AddedItems.Count > 0 && e.AddedItems[0] is ChargeUnit)
				{
					this.tbResult.Text = ((ChargeUnit)e.AddedItems[0]).ChargeUnitDescription;
				}
				else
				{
					this.tbResult.Text = "NONE";
				}
			}
			public class ChargeUnit : INotifyPropertyChanged
			{
				private string _chargeUnitDescription;
				private int _chargeUnitListValueId;
				public event PropertyChangedEventHandler PropertyChanged;
				public ChargeUnit()
				{
				}
				private void OnPropertyChanged(string propertyName)
				{
					if (PropertyChanged != null)
					{
						PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
					}
				}
				public string ChargeUnitDescription
				{
					get { return _chargeUnitDescription; }
					set
					{
						_chargeUnitDescription = value;
						OnPropertyChanged("ChargeUnitDescription");
					}
				}
				public int ChargeUnitListValueId
				{
					get { return _chargeUnitListValueId; }
					set
					{
						_chargeUnitListValueId = value;
						OnPropertyChanged("ChargeUnitListValueId");
					}
				}
			}
			public class ClientRatesViewModel
			{
				public ClientRatesViewModel()
				{
					_chargeUnits = new List<ChargeUnit>();
					for (int i = 0; i < 10; i++)
					{
						_chargeUnits.Add(new ChargeUnit() { ChargeUnitDescription = i.ToString(), ChargeUnitListValueId = i });
					}
				}
				private List<ChargeUnit> _chargeUnits;
				public List<ChargeUnit> ChargeUnits
				{
					get { return _chargeUnits; }
					set { _chargeUnits = value; }
				}
				
			}
		}
	}	
