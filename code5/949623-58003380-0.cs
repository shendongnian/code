    xmlns:converter="clr-namespace:ProjectName.Converters"
    <Window.Resource>
     <converter:BindableConverter x:Key="bindableConverter"/>
    </Window.Resource>    
    <DataGridTemplateColumn Header="HeaderName">
                                    <DataGridTemplateColumn.CellTemplate>
                                        <DataTemplate>
                                            <Image x:Name="BindImg" Height="35" Width="35" Source="{Binding IsBindable,Converter={StaticResource bindableConverter}}" VerticalAlignment="Center" HorizontalAlignment="Center"/>
                                        </DataTemplate>
                                    </DataGridTemplateColumn.CellTemplate>                             
                                </DataGridTemplateColumn> 
    
    
     public class BindableConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                string imageSource = string.Empty;
                bool isBinded;
                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                {
                    imageSource = "../../Resource/Images/unbinded.jpg";
                }
                if (Boolean.TryParse(value.ToString(), out isBinded))
                {
                    if (isBinded)
                    {
                        imageSource = "../../Resource/Images/binded.jpg";
                    }
                    else
                    {
                        imageSource = "../../Resource/Images/unbinded.jpg";
                    }
                }
                return imageSource;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
