	<DataGrid ItemsSource="{Binding Employees}" AutoGenerateColumns="False">
		<DataGrid.Columns>
			<DataGridTextColumn Binding="{Binding EmployeeName}"/>
			<!-- Displays the items of the first collection-->
			<DataGridTemplateColumn>
				<DataGridTemplateColumn.CellTemplate>
					<DataTemplate>
						<ListBox ItemsSource="{Binding Dogs}"/>
					</DataTemplate>
				</DataGridTemplateColumn.CellTemplate>
			</DataGridTemplateColumn>
			<!-- Displays the items of the second collection-->
			<DataGridTemplateColumn>
				<DataGridTemplateColumn.CellTemplate>
					<DataTemplate>
						<ListBox ItemsSource="{Binding Cats}"/>
					</DataTemplate>
				</DataGridTemplateColumn.CellTemplate>
			</DataGridTemplateColumn>
		</DataGrid.Columns>
	</DataGrid>
