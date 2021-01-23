    <DataGridComboBoxColumn>
        <DataGridComboBoxColumn.EditingElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding Animals}"/>
                <Setter Property="DisplayMemberPath" Value="AnimalName"/>
            </Style>
        </DataGridComboBoxColumn.EditingElementStyle>
        <DataGridComboBoxColumn.ElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding Animals}"/>
                <Setter Property="DisplayMemberPath" Value="AnimalName"/>
            </Style>
        </DataGridComboBoxColumn.ElementStyle>
    </DataGridComboBoxColumn>
