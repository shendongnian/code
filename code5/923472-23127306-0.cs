    <DataGrid x:Name="PhoneNumbersDataGrid" HorizontalAlignment="Left" Grid.Column="3" Grid.Row="11" VerticalAlignment="Top" Height="86" Width="auto" ItemsSource="{Binding PhoneNumbers, Mode=TwoWay}" AutoGenerateColumns="False" IsReadOnly="True">
                <DataGrid.Columns>
                    <DataGridTextColumn Binding="{Binding PhoneNumber,Mode=TwoWay}" Header="Phone Number" IsReadOnly="True"/>
                    <DataGridTemplateColumn Header="Delete">
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <Button Command="{Binding Guest.DeletePhoneCommand, Mode=OneWay, Source={StaticResource Locator}}">Delete</Button>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>
