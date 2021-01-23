    <DataGridComboBoxColumn SelectedItemBinding="{Binding Name}">
        <DataGridComboBoxColumn.EditingElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource"
                        Value="{Binding DataContext.AnotherCollection,
                                   RelativeSource={RelativeSource Mode=FindAncestor, 
                                                             AncestorType=Window}}"/>
                <Setter Property="DisplayMemberPath" Value="Name"/>
            </Style>
        </DataGridComboBoxColumn.EditingElementStyle>
        <DataGridComboBoxColumn.ElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource"
                        Value="{Binding DataContext.AnotherCollection,
                                  RelativeSource={RelativeSource Mode=FindAncestor, 
                                                             AncestorType=Window}}"/>
                <Setter Property="DisplayMemberPath" Value="Name"/>
            </Style>
        </DataGridComboBoxColumn.ElementStyle>
    </DataGridComboBoxColumn>
