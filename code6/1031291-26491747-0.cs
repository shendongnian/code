      <Grid>
            <Grid.Resources>
                <local:RoleValueConverter x:Key="converter"></local:RoleValueConverter>
            </Grid.Resources>
            <ListBox ItemsSource="{Binding AllRoles}" >
                <ListBox.ItemTemplate>
                    <DataTemplate>
                        <CheckBox Content="{Binding Name}" >
                            <CheckBox.IsChecked>
                                <MultiBinding Converter="{StaticResource converter}">
                                    <Binding Path="."></Binding>
                                    <Binding  RelativeSource="{RelativeSource AncestorType={x:Type ListBox}}"  Path="DataContext"></Binding>
                                </MultiBinding>
                            </CheckBox.IsChecked>
                        </CheckBox>
                    </DataTemplate>
                </ListBox.ItemTemplate>
            </ListBox>
        </Grid>
     public class RoleValueConverter : IMultiValueConverter
        {
        
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
               //values[0] is Role object
        //value[1] is UserManagerViewModel 
       // then you can see if Selected user had Role object return true else return false 
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
