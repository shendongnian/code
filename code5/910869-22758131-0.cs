    <ItemsControl ItemsSource="{Binding Bar">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <CheckBox Style="{StaticResource LedCheckBox}" 
                          IsChecked="{Binding Value, 
                                              Mode=TwoWay,
                                              Converter={StaticResource ValueToLedConverter},
                                              UpdateSourceTrigger=PropertyChanged}"
                          ToolTip="{Binding Name}"/>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
