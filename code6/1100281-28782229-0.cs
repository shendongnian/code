    ...
    <DataGridComboBoxColumn Header="Symbol Subscriptions" >
        <DataGridComboBoxColumn.ElementStyle>
            <Style TargetType="{x:Type ComboBox}">
                <Setter Property="ItemsSource" Value="{Binding Path=SubscribedSymbols}" />
            </Style>
        </DataGridComboBoxColumn.ElementStyle>
        <DataGridComboBoxColumn.EditingElementStyle>
            <Style TargetType="{x:Type ComboBox}">
                <Setter Property="ItemsSource" Value="{Binding Path=SubscribedSymbols}" />
            </Style>
        </DataGridComboBoxColumn.EditingElementStyle>
    </DataGridComboBoxColumn>
    ...
