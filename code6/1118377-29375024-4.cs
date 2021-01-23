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
			
			public class ChargeUnit : INotifyPropertyChanged
			{
				private string _chargeUnitDescription;
				private int _chargeUnitListValueId;
				public ChargeUnit()
				{
				}
				public string ChargeUnitDescription
				{
					get { return _chargeUnitDescription; }
					set
					{
						_chargeUnitDescription = value;
						OnPropertyChanged();
					}
				}
				public int ChargeUnitListValueId
				{
					get { return _chargeUnitListValueId; }
					set
					{
						_chargeUnitListValueId = value;
						OnPropertyChanged();
					}
				}
				public event PropertyChangedEventHandler PropertyChanged;
				protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
				{
					PropertyChangedEventHandler tmp = this.PropertyChanged;
					if (tmp != null)
					{
						tmp(this, new PropertyChangedEventArgs(propertyName));
					}
				}
			}
			public class ClientRatesViewModel : INotifyPropertyChanged
			{
				public ClientRatesViewModel()
				{
					_chargeUnits = new List<ChargeUnit>();
					for (int i = 0; i < 10; i++)
					{
						_chargeUnits.Add(new ChargeUnit() { ChargeUnitDescription = i.ToString(), ChargeUnitListValueId = i });
					}
				}
				protected ChargeUnit _SelectedItem;
				public ChargeUnit SelectedItem
				{
					get
					{
						return this._SelectedItem;
					}
					set
					{
						if(this._SelectedItem == value)
						{
							return;
						}
						this._SelectedItem = value;
						this.OnPropertyChanged();
					}
				}
				
				private List<ChargeUnit> _chargeUnits;
				public List<ChargeUnit> ChargeUnits
				{
					get { return _chargeUnits; }
					set 
					{
						if(this._chargeUnits == value)
						{
							return;
						}
						_chargeUnits = value;
						this.OnPropertyChanged();
					}
				}
				public event PropertyChangedEventHandler PropertyChanged;
				protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
				{
					PropertyChangedEventHandler tmp = this.PropertyChanged;
					if (tmp != null)
					{
						tmp(this, new PropertyChangedEventArgs(propertyName));
					}
				}
			}
		}
	}	
