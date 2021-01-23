    <DataGridComboBoxColumn>
        <DataGridComboBoxColumn.EditingElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource"
                        Value="{Binding DataContext.AnotherCollection,
                                  RelativeSource={RelativeSource Mode=FindAncestor, 
                                                            AncestorType=Window}}"/>
            </Style>
        </DataGridComboBoxColumn.EditingElementStyle>
    </DataGridComboBoxColumn>
