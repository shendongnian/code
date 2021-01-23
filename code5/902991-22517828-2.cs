    <Style Name="RightAlign" TargetType="{x:Type TextBlock}">
        <Setter Property="HorizontalAlignment" Value="Right" />
    </Style>
...
    <DataGrid.Columns>
        <DataGridTextColumn Binding="{Binding SomeTextColumn}" />
        <DataGridTextColumn Binding="{Binding SomeNumericColumn}"
            ElementStyle="{StaticResource RightAlign}" ... />
        <DataGridTextColumn Binding="{Binding AnotherTextColumn}" />
        ...
    </DataGrid.Columns>
