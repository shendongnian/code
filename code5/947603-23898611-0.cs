	<ListBox ItemsSource="{Binding Path=ModelItem.ReplaceItems, Mode=OneWay}">
		<ListBox.ItemTemplate>
			<DataTemplate>
				<Grid>
				<Grid.ColumnDefinitions>
					<ColumnDefinition />
					<ColumnDefinition />
				</Grid.ColumnDefinitions>
				<TextBlock Grid.Column="0" Text="{Binding Path=ModelItem.Rwht}" />
				<TextBlock Grid.Column="1" Text="{Binding Path=ModelItem.Rwth}" />
				</Grid>
			</DataTemplate>
		</ListBox.ItemTemplate>
	</ListBox>
