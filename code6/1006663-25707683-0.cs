    <DataGrid x:Name="DG" ItemsSource="{Binding}" AutoGenerateColumns="False">
     <DataGrid.Columns>
          <DataGridTemplateColumn CellStyle="{StaticResource ResourceKey=Button}">
                  <DataGridTemplateColumn.CellTemplate>
                     <DataTemplate>
                          <Button Content="Delete" Command="{Binding DataContext.DeleteCommand,
                              RelativeSource={RelativeSource AncestorType=DataGrid}}"/>
                     </DataTemplate>
                 </DataGridTemplateColumn.CellTemplate>
           </DataGridTemplateColumn>
     </DataGrid.Columns>
     </DataGrid>
