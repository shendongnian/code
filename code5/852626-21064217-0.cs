    <DataGrid Name="EmployeeContentView"
              Margin="10,10,10,10"
              RowHeight="20"
              AutoGenerateColumns="True"    
              ItemsSource="{Binding}"          
              Height="auto" Width="auto">
        <DataGrid.Columns>
            <DataGridTemplateColumn Header="Married">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <Image x:Name="IMG" Source="present.png" />
                        <DataTemplate.Triggers>
                            <DataTrigger Binding="{Binding Path=IsPRESENT}" Value="False">
                                <Setter Property="Source" Value="notpresent.png" TargetName="IMG"/>
                            </DataTrigger>
                        </DataTemplate.Triggers>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
