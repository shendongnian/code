    <Window.Resources>
                <local:ChoiceToVisibilityConverter x:Key="choice2visibilityConverter" />
        </Window.Resources>
     <DataGrid.Columns>
            <DataGridTemplateColumn Header="Name" >
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <StackPanel  Height="30">
                            <TextBox   Name="tbName"  Width="100"  Visibility="{Binding SelectedRow.Choice, Converter={StaticResource choice2visibilityConverter}, ConverterParameter=fromTextBox}"/>
                            <Button Name="btn1" Content="ADD ME" Width="100"  Visibility="{Binding SelectedRow.Choice, Converter={StaticResource choice2visibilityConverter}, ConverterParameter=fromButton}"/>
                        </StackPanel>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
            <DataGridTemplateColumn Header="Choice" Width="150" >
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <ComboBox  Name="combo1"  SelectedValue="{Binding SelectedRow.Choice}" SelectedValuePath="Content" >
                            <ComboBoxItem Content="ShowButton" />
                            <ComboBoxItem Content="ShowText" />
                        </ComboBox>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
