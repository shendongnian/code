        public class MyBinding : Binding
    {
        public MyBinding()
            :base()
        {
            this.Mode = BindingMode.TwoWay;
            this.ValidatesOnDataErrors = true;
            this.ValidatesOnExceptions = true;
            this.UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged;
        }
        public MyBinding(string path) 
            : base(path)
        {
            this.Mode = BindingMode.TwoWay;
            this.ValidatesOnDataErrors = true;
            this.ValidatesOnExceptions = true;
            this.UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged;
        }
    }
    <Window x:Class="WpfApplication1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="clr-namespace:WpfApplication1"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <TextBox x:Name="txt">
            <TextBox.Text>
                <local:MyBinding Path="Value" />
            </TextBox.Text>
        </TextBox>
    </Grid>
