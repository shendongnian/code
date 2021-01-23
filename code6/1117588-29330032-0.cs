     <Button x:Name="Bt_RemoveReports" Content="Supprimer Rapport" IsEnabled="{Binding ElementName=DG_Reports, 
            NotifyOnSourceUpdated=True, Path=SelectedItems.Count, Converter={StaticResource SelectedDataGridRowsToBooleanConverter}}">
            <i:Interaction.Triggers>
                <i:EventTrigger EventName="Click">
                    <command:EventToCommand Command="{Binding DeleteReports}" CommandParameter="{Binding ElementName=DG_Reports, Path=SelectedItems}"/>
                </i:EventTrigger>
            </i:Interaction.Triggers>
        </Button>
    public class SelectedDataGridRowsToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value > 0;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
