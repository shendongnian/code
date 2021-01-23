AttachedDependencyProperty
    public static class UserControlExtension
    {
        public static readonly DependencyProperty ActionProperty;
        public static void SetAction(DependencyObject DepObject, ICommand value)
        {
            DepObject.SetValue(ActionProperty, value);
        }
        public static ICommand GetAction(DependencyObject DepObject)
        {
            return (ICommand)DepObject.GetValue(ActionProperty);
        }
        static UserControlExtension()
        {
            ActionProperty = DependencyProperty.RegisterAttached("Action",
                                                                typeof(ICommand),
                                                                typeof(UserControlExtension));
        }
    }
TestViewModel
    public class TestViewModel
    {
        private ICommand _testButtonCommand = null;
        public ICommand TestButtonCommand
        {
            get
            {
                if (_testButtonCommand == null)
                {
                    _testButtonCommand = new RelayCommand(param => this.TestButton(), null);
                }
                return _testButtonCommand;
            }
        }
        private void TestButton() 
        {
            MessageBox.Show("Test command execute");
        }
    }
MainWindow
    <Window.Resources>
        <local:TestViewModel x:Key="TestVM" />
    </Window.Resources>
    
    <Grid DataContext="{StaticResource TestVM}">
        <local:TestUserControl x:Name="TestUserControl"
                               AttachedProperties:UserControlExtension.Action="{Binding TestButtonCommand}" />
    </Grid>
UserControl
    <Grid>
        <Button Name="TestButton"
                HorizontalAlignment="Center" 
                VerticalAlignment="Center"
                Content="TestContent"
                Command="{Binding RelativeSource={RelativeSource AncestorType={x:Type UserControl}}, 
                                  Path=(AttachedProperties:UserControlExtension.Action)}" />        
    </Grid>
