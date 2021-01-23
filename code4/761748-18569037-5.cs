    <ComboBox SelectedItem="{Binding Color, Mode=TwoWay}" 
              ItemsSource="{l:EnumValues {x:Type l:MyEnum}}">
        <FrameworkElement.Resources>
            <l:EnumValueToDecriptionConverter x:Key="EnumValueToDecriptionConverter" />
        </FrameworkElement.Resources>
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Mode=OneTime,
                           Converter={StaticResource EnumValueToDecriptionConverter}}" />
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
