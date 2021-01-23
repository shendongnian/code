	<DataGrid ItemsSource="{Binding Source}" SelectedItem="{Binding SelectedItemProperty, Mode=TwoWay}">
		<DataGrid.ContextMenu>
			<ContextMenu>
				<MenuItem Command="{Binding MyCommand}" Header="MyCommand"/>
			</ContextMenu>
		</DataGrid.ContextMenu>
		<DataGrid.Columns>
			<DataGridTextColumn Header="Name" Binding="{Binding Key, Mode=TwoWay}" Width="1*"/>
			<DataGridTextColumn Header="Value" Binding="{Binding Value, Mode=TwoWay}" Width="3*"/>
		</DataGrid.Columns>
	</DataGrid>
