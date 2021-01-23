    <DataGridComboBoxColumn x:Name="Whatever">                    
         <DataGridComboBoxColumn.EditingElementStyle>
              <Style TargetType="{x:Type ComboBox}">
                   <EventSetter Event="SelectionChanged" Handler="SomeSelectionChanged" />
              </Style>
         </DataGridComboBoxColumn.EditingElementStyle>           
    </DataGridComboBoxColumn>
