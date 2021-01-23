    <DataGrid ItemsSource="{Binding MyItems}" IsReadOnly="{Binding IsReadOnly}" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Name">
                    <DataGridTextColumn.Binding Path="Name" UpdateSourceTrigger="PropertyChanged">
                        <DataGridTextColumn.Binding.ValidationRules>
                            <DataErrorValidationRule/>
                       </DataGridTextColumn.Binding.ValidationRules>
                   </DataGridTextColumn.Binding>
                </DataGridTextColumn>
              </DataGrid.Columns>
     </DataGrid>
