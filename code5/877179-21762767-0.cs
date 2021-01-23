    <MenuItem Header="{DynamicResource DecimalPlaces}" ItemsSource="{Binding MenuItems}">
        <ExclusiveMenuItem:ExclusiveMenuItem Header="1" IsCheckable="True" IsChecked="{Binding Path=DecimalPlaces}"/>
        <ExclusiveMenuItem:ExclusiveMenuItem Header="2" IsCheckable="True" IsChecked="{Binding Path=DecimalPlaces}"/>
        <ExclusiveMenuItem:ExclusiveMenuItem Header="OneDecimal" IsCheckable="True" IsChecked="{Binding Path=DecimalPlaces}"/>
        <ExclusiveMenuItem:ExclusiveMenuItem Header="TwoDecimal" IsCheckable="True" IsChecked="{Binding Path=DecimalPlaces}"/>
    </MenuItem>
