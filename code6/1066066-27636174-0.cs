       <TabControl Grid.Row="1">
            <TabItem Header="Second">
                <DataGrid AutoGenerateColumns="False">
                    <DataGrid.Columns>
                        <DataGridTemplateColumn>
                            <DataGridTemplateColumn.HeaderTemplate>
								<DataTemplate>
									<TextBlock Text="{Binding DataContext.SelectedItem, RelativeSource={RelativeSource  Mode=FindAncestor, AncestorType=Window}}" />
								</DataTemplate>
							</DataGridTemplateColumn.HeaderTemplate>
													
                        </DataGridTemplateColumn>
                    </DataGrid.Columns>
                </DataGrid>
            </TabItem>
            <TabItem Header="First">
                <DataGrid AutoGenerateColumns="False">
                    <DataGrid.Columns>												
                        <DataGridTemplateColumn>
							 <DataGridTemplateColumn.HeaderTemplate>
								<DataTemplate>
									<TextBlock Text="{Binding DataContext.SelectedItem, RelativeSource={RelativeSource  Mode=FindAncestor, AncestorType=Window}}" />
								</DataTemplate>
							</DataGridTemplateColumn.HeaderTemplate>							
                        </DataGridTemplateColumn>
                    </DataGrid.Columns>
                </DataGrid>
            </TabItem>
        </TabControl>
