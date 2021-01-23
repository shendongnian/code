    <TextBlock>Profession</TextBlock>                     
    <TextBox Name="txtSpec" Text="{Binding Speciality}" />
    <ComboBox Name="cmbSpec" SelectedIndex="{Binding Speciality, Converter={StaticResource EnumConverter}}">
        <ComboBoxItem>Software engineer</ComboBoxItem>
        <ComboBoxItem>Mechanic</ComboBoxItem>
    </ComboBox>
