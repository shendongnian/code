     <CheckBox Name="MinDateCheck" IsChecked="{Binding MinDate, Converter={StaticResource DateTimeConverter}, Mode=OneWayToSource}"></CheckBox>
        <DatePicker IsEnabled="{Binding ElementName=MinDateCheck, Path=IsChecked}"
                    SelectedDate="{Binding MinDate}">
            <DatePicker.Style>
                <Style TargetType="{x:Type DatePicker}">
                  
                    <Style.Triggers>
                        <Trigger Property="IsEnabled"  Value="False">
                            <Setter Property="SelectedDate" Value="{x:Null}" />
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </DatePicker.Style>
        </DatePicker>
    
    class DateTimeConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (!(bool)value)
                {
                    return null;
                }
                else
                {
                    return DependencyProperty.UnsetValue;
                }
            }
        }
