       <DataGrid ItemsSource="{Binding Model.Collection}"  >
            <DataGrid.Columns>
                <!-- Row Number -->
                <DataGridTextColumn Width="SizeToCells"  Binding="{Binding rowNum}">
                    
                </DataGridTextColumn>
                <!-- Inputs -->
                <DataGridTextColumn Width="SizeToCells" Header="Inputs" Binding="{Binding input}" >
                    <DataGridTextColumn.CellStyle>
                        <Style TargetType="DataGridCell">
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding input}" Value="Four">
                                    <Setter Property="IsEnabled" Value="false"/>
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </DataGridTextColumn.CellStyle>
                </DataGridTextColumn>
                <!-- Outputs -->
                <DataGridTextColumn Width="SizeToCells" IsReadOnly="False" Header="Outputs" Binding="{Binding output}" />
            </DataGrid.Columns>
        </DataGrid>
