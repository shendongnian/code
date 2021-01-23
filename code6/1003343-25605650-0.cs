    <DataGrid x:Name="dtGrid" AutoGenerateColumns="False" IsReadOnly="True">
      <DataGrid.Columns>
       <DataGridTextColumn Header="Col1" Binding="{Binding Col1}" />
         <DataGridTextColumn Header="Col2" Binding="{Binding Col2}" />
           <DataGridTemplateColumn Header="ButtonsList">
             <DataGridTemplateColumn.CellTemplate>
               <DataTemplate>
                  <Button Content="{Binding ButtonsList.Content}" ToolTip="{Binding ButtonsList.ToolTip}"/>
               </DataTemplate>
            </DataGridTemplateColumn.CellTemplate>
         </DataGridTemplateColumn>
      </DataGrid.Columns>
    </DataGrid>
