	public class MyTextBox : TextBox
	{
		public MyTextBox()
		{
		}
		protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
		{
			Console.WriteLine(string.Format("Property changed: {0} {1}", e.Property.Name, e.NewValue));
			base.OnPropertyChanged(e);
		}
	}
    <Window x:Class="WpfApplication1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
		xmlns:local="clr-namespace:WpfApplication1"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
		<local:MyTextBox x:Name="TB" Height="150"></local:MyTextBox>
    </Grid>
    </Window>
