    <DataGridComboBoxColumn Header="Region" DisplayMemberPath="regionShortCode" 
        Width="SizeToHeader">
        <DataGridComboBoxColumn.ElementStyle>
            <Style>
                <Setter Property="ComboBox.ItemsSource" Value="{Binding 
                    DataContext.MembershipsCollection, RelativeSource={RelativeSource 
                    AncestorType={x:Type YourViewModelsPrefix:YourViewModel}}}" />
            </Style>
        </DataGridComboBoxColumn.ElementStyle>
        <DataGridComboBoxColumn.EditingElementStyle>
            <Style>
                <Setter Property="ComboBox.ItemsSource" Value="{Binding 
                    DataContext.MembershipsCollection, RelativeSource={RelativeSource 
                    AncestorType={x:Type YourViewsPrefix:YourView}}}" />
            </Style>
        </DataGridComboBoxColumn.EditingElementStyle>
    </DataGridComboBoxColumn>
