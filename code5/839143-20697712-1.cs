    <Datagrid>
		<DataGrid.Columns>
		   <DataGridTemplateColumn Header="Left">
				<DataGridTemplateColumn.CellTemplate>
					<DataTemplate>
						<ComboBox Name="Leftcombo" ItemsSource="{Binding Path=DataContext.Column, Mode=TwoWay, RelativeSource={RelativeSource AncestorType=Window}}" 
								  SelectedItem="{Binding SelectedColumn, UpdateSourceTrigger=PropertyChanged}"/>
					</DataTemplate>
				</DataGridTemplateColumn.CellTemplate>
			</DataGridTemplateColumn>
			<DataGridTextColumn Header="Right" Binding="{Binding SelectedColumn, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
		</DataGrid.Columns>
	</DataGrid>
