         <ItemsControl Grid.Row="1" ItemsSource="{Binding Collection}" >
                    <ItemsControl.ItemContainerStyle>
                        <Style>
                            <Setter Property="Control.ToolTip">
                                <Setter.Value>
                                    <MultiBinding Converter="{StaticResource MyConverter}">
                                        <Binding Path="IsMouseOver" RelativeSource="{RelativeSource Self}"/>
                                        <Binding />
                                        <Binding Path="ItemsSource" RelativeSource="{RelativeSource Mode=FindAncestor, AncestorType=ItemsControl}"/>
                                    </MultiBinding>
                                </Setter.Value>
                            </Setter>
                        </Style>
                    </ItemsControl.ItemContainerStyle>
                    <ItemsControl.ItemsPanel>
                        <ItemsPanelTemplate>
                            <StackPanel Orientation="Vertical" />
                        </ItemsPanelTemplate>
                    </ItemsControl.ItemsPanel>
                </ItemsControl>
    
      public partial class MainWindow : Window
        {
            private ObservableCollection<string> collection;
    
            public ObservableCollection<string> Collection
            {
                get { return collection; }
                set { collection = value; }
            }
    
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;
                collection = new ObservableCollection<string>();
                collection.Add("First");
                collection.Add("Second");
                collection.Add("Third");
                collection.Add("Fourth");
               
            }
        }
    
         public class MyConverter : IMultiValueConverter
            {
                public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    if ((bool)values[0])
                    {
                        return (values[2] as ObservableCollection<string>).IndexOf(values[1].ToString());
                    }
                    else
                        return "";
                }
        
                public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
                {
                    throw new NotImplementedException();
                }
            }
