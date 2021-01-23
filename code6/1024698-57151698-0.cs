    <DataGrid Name="dgMaterialSorter" AutoGenerateColumns="False" Grid.Column="1" VerticalAlignment="Stretch" HorizontalAlignment="Stretch" 
			  PreparingCellForEdit="dgMaterialSorter_PreparingCellForEdit" 
			  CellEditEnding="dgMaterialSorter_CellEditEnding">
		<DataGrid.Columns>
			<DataGridTextColumn Header="" Binding="{Binding MaterialName}"  IsReadOnly="true" Width="Auto" HeaderStyle="{StaticResource GridHdr_Right}" CellStyle="{StaticResource GridCol_Right}"/>
			<DataGridTextColumn Header="Code" Binding="{Binding MaterialCode}"  IsReadOnly="true" Width="Auto" HeaderStyle="{StaticResource GridHdr_Center}" CellStyle="{StaticResource GridCol_Center}" />
			<DataGridTemplateColumn Header="Qty"  HeaderStyle="{StaticResource GridHdr_Center}" CellStyle="{StaticResource GridCol_Center}"  >
				<DataGridTemplateColumn.CellTemplate>
					<DataTemplate>
						<TextBlock Text="{Binding Quantity}"/>
					</DataTemplate>
				</DataGridTemplateColumn.CellTemplate>
				<DataGridTemplateColumn.CellEditingTemplate>
					<DataTemplate>
						<TextBox x:Name="EditTextbox" Text="{Binding Quantity, Mode=TwoWay, UpdateSourceTrigger=LostFocus, ValidatesOnDataErrors=True}" />
					</DataTemplate>
				</DataGridTemplateColumn.CellEditingTemplate>
			</DataGridTemplateColumn>
		</DataGrid.Columns>
	</DataGrid>
-
    private void dgMaterialSorter_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
	{
		if (e.EditAction == DataGridEditAction.Commit)
		{
			BindingExpression binding = (BindingExpression)e.EditingElement.BindingGroup.BindingExpressions[0];
			string bindingField = binding.ResolvedSourcePropertyName;
			if (bindingField.Equals(nameof(MaterialSorter.Quantity))) { /*DO SOMETHING*/ }
		}
	}
