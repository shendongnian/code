        <DataGrid ItemsSource="{Binding MyDataList}" AutoGenerateColumns="False">
          <DataGrid.Columns>            
           <DataGridTextColumn Header="TextColumn1" Binding="{Binding FirstName}" />
           <DataGridTextColumn Header="TextColumn1" Binding="{Binding LastName}" />
           <DataGridTextColumn Header="TextColumn1" Binding="{Binding Address}" />
           
           <DataGridTemplateColumn Header="CheckBoxColumn1">
              <DataGridTemplateColumn.CellTemplate>
                  <DataTemplate>
                      <CheckBox IsChecked="{Binding IsActive}"/>
                  </DataTemplate>
              </DataGridTemplateColumn.CellTemplate>
           </DataGridTemplateColumn>
    
           <DataGridTemplateColumn Header="CheckBoxColumn2">
              <DataGridTemplateColumn.CellTemplate>
                  <DataTemplate>
                      <CheckBox IsChecked="{Binding IsAlive}"/>
                  </DataTemplate>
              </DataGridTemplateColumn.CellTemplate>
           </DataGridTemplateColumn>
    
           <DataGridTemplateColumn Header="CheckBoxColumn3">
              <DataGridTemplateColumn.CellTemplate>
                  <DataTemplate>
                      <CheckBox IsChecked="{Binding IsParticipating}"/>
                  </DataTemplate>
              </DataGridTemplateColumn.CellTemplate>
          </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>  
      
