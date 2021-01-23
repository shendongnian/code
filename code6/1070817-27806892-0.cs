        <DataGridComboBoxColumn Header="Available Values" SelectedItemBinding=
                     "{Binding SelectedAvailableValue, UpdateSourceTrigger=PropertyChanged}"                     
                     DisplayMemberPath="Label">
                <DataGridComboBoxColumn.EditingElementStyle>
                   <Style TargetType="ComboBox">
                      <Setter Property="ItemsSource" Value="{Binding Path=AvailableValues}" />
                   </Style>
                </DataGridComboBoxColumn.EditingElementStyle>
      </DataGridComboBoxColumn> 
