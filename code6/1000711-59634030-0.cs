<UserControl
    ...
    x:Name="MyUserControl">
    ...
    <Label Content="{Binding MyProperty, ElementName=MyUserControl}"
    ...
MyControl.xaml.cs:
public partial class MyControl: UserControl, INotifyPropertyChanged
{
    ...
    private string _myProperty = "";
	public string MyProperty
	{
		get => _myProperty ;
		set
		{
			if (value == _myProperty ) return;
			_myProperty = value;
			OnPropertyChanged();
		}
	}
	public event PropertyChangedEventHandler PropertyChanged;
	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
    ...
