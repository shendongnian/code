XAML
    <Grid>
        <TextBlock Name="SampleTextBlock" Width="200" Height="30" 
                   Background="AntiqueWhite" Text="Sample TextBlock" 
                   local:MyDependencyClass.MyPropertyForTextBlock="TestString" />
        <StackPanel Width="100" Height="100" HorizontalAlignment="Left">
            <Button Name="GetValueButton" Content="GetValueButton" Click="GetValue_Click" />
            <Button Name="SetValueButton" Content="SetValueButton" Click="SetValue_Click" />
        </StackPanel>
    </Grid>
Code behind
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void GetValue_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(MyDependencyClass.GetMyPropertyForTextBlock(SampleTextBlock));
        }
        private void SetValue_Click(object sender, RoutedEventArgs e)
        {
            MyDependencyClass.SetMyPropertyForTextBlock(SampleTextBlock, "New Value");
            MessageBox.Show(MyDependencyClass.GetMyPropertyForTextBlock(SampleTextBlock));
        }
    }
    public class MyDependencyClass : DependencyObject
    {
        public static readonly DependencyProperty MyPropertyForTextBlockProperty;
        public static void SetMyPropertyForTextBlock(DependencyObject DepObject, string value)
        {
            DepObject.SetValue(MyPropertyForTextBlockProperty, value);
        }
        public static string GetMyPropertyForTextBlock(DependencyObject DepObject)
        {
            return (string)DepObject.GetValue(MyPropertyForTextBlockProperty);
        }
        static MyDependencyClass()
        {
            PropertyMetadata MyPropertyMetadata = new PropertyMetadata(string.Empty);
            MyPropertyForTextBlockProperty = DependencyProperty.RegisterAttached("MyPropertyForTextBlock",
                                                                typeof(string),
                                                                typeof(MyDependencyClass),
                                                                MyPropertyMetadata);
        }
    }
