    <MenuItem Header="{DynamicResource DecimalPlaces}" ItemsSource="{Binding MenuItems}">
        <MenuItem.ItemContainerStyle>
            <Style TargetType="MenuItem">
                <Setter Property="Header" Value="{Binding SomeProperty}" />
                <Setter Property="IsCheckable" Value="True" />
                <Setter Property="IsChecked" Value="{Binding Path=DecimalPlaces}" />
            </Style>
        </MenuItem.ItemContainerStyle>
    </MenuItem>
