    <DataGridComboBoxColumn>
        <DataGridComboBoxColumn.EditingElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding Animals}"/>
                <Setter Property="DisplayMemberPath" Value="AnimalName"/>
                <Setter Property="SelectedItem" Value="{Binding SelectedAnimal}"/>
            </Style>
        </DataGridComboBoxColumn.EditingElementStyle>
        <DataGridComboBoxColumn.ElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding Animals}"/>
                <Setter Property="DisplayMemberPath" Value="AnimalName"/>
                <Setter Property="SelectedItem" Value="{Binding SelectedAnimal}"/>
            </Style>
        </DataGridComboBoxColumn.ElementStyle>
    </DataGridComboBoxColumn>
