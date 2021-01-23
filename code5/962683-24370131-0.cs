      <DataGrid.ColumnHeaderStyle>
                        <Style TargetType="DataGridColumnHeader">
                            <Setter Property="ContentTemplate">
                                <Setter.Value>
                                    <DataTemplate>
                                        <CheckBox x:Name="HeaderCheckBox" Content="{Binding}"
                                         Checked="CheckBoxChanged" Unchecked="CheckBoxChanged"/>
                                    </DataTemplate>
                                </Setter.Value>
                            </Setter>
                        </Style>
            </DataGrid.ColumnHeaderStyle>
    
         private void CheckBoxChanged(object sender, RoutedEventArgs e)
         {
                    // add what you want
         }
