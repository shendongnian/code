           <GridView ScrollViewer.HorizontalScrollBarVisibility="Auto">
                <GridViewColumn Header="Amount"  >
                    <GridViewColumn.CellTemplate >
                        <DataTemplate >
                            <StackPanel Width="200"  >
                                <TextBlock Foreground="Black"  TextAlignment="Right" Text="{Binding Path=Amount, StringFormat=N2}"/>
                            </StackPanel>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
            </GridView>
