    <DataGrid ItemsSource="{Binding MyList}"
          AutoGenerateColumns="False">
    <DataGrid.Columns>
        <DataGridTextColumn Header="Test Character Casing"
                            Binding="{Binding Name}">
            <DataGridTextColumn.EditingElementStyle>
                <Style TargetType="TextBox">
                    <Setter Property="CharacterCasing" Value="Upper"/>
                </Style>
            </DataGridTextColumn.EditingElementStyle>
        </DataGridTextColumn>
    </DataGrid.Columns>
