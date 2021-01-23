            <DataGrid.Columns>
                <DataGridTextColumn Header="Item Name" Binding="{Binding Item.ItemName}" Width="*" IsReadOnly="True"/>
                <DataGridTextColumn Header="Price" Binding="{Binding SalePrice,Mode=TwoWay}" Width="100" IsReadOnly="False"  />
                <DataGridTextColumn Header="Quantity" Binding="{Binding Quantity,Mode=TwoWay}" Width="100" IsReadOnly="False"  />
            </DataGrid.Columns>
            <DataGrid.RowDetailsTemplate>
                <DataTemplate>
                    <ListBox ItemsSource="{Binding ocChoiceRecord, ElementName=myRoot}">
                        <ListBox.ItemTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding {RelativeSource FindAncestor, AncestorType=DataGrid} RecordDescription}" />
                            </DataTemplate>
                        </ListBox.ItemTemplate>
                    </ListBox>
                </DataTemplate>
            </DataGrid.RowDetailsTemplate>
        </DataGrid>
