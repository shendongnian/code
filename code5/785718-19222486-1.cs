              <GridViewColumn Header="Admin" Width="70">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <CheckBox IsChecked="{Binding Path=IsAdmin, Converter={StaticResource strToBoolConverter}}"/>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
