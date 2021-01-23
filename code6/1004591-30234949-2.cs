               <DataGridComboBoxColumn Header="Category"
    SelectedValueBinding="{Binding category_cde}"
      SelectedValuePath="category_cde"
    DisplayMemberPath="category_dsc">
                            <DataGridComboBoxColumn.ElementStyle>
                                <Style TargetType="ComboBox">
                                <Setter Property="ItemsSource" Value="{Binding Path=CATEGORIES , RelativeSource={RelativeSource AncestorType={x:Type UserControl}}}" />
                                </Style>
                            </DataGridComboBoxColumn.ElementStyle>
                            <DataGridComboBoxColumn.EditingElementStyle>
                                <Style TargetType="ComboBox">
                                <Setter Property="ItemsSource" Value="{Binding Path=CATEGORIES , RelativeSource={RelativeSource AncestorType={x:Type UserControl}}}" />
                                </Style>
                            </DataGridComboBoxColumn.EditingElementStyle>
                        </DataGridComboBoxColumn>
                 
                </DataGrid.Columns>
            </DataGrid>
