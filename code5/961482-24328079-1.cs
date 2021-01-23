    <Window>
      <Grid>
		 <Grid.Resources>
			<local:InverseConverter x:Key="converter" />
		 </Grid.Resources>
		 <DataGrid ItemsSource="{Binding Stuff}">
			<DataGrid.Columns>
				<DataGridTemplateColumn>
					<DataGridTemplateColumn.CellTemplate>
						<DataTemplate>
							<RadioButton IsChecked="{Binding Path=IsEnabled, RelativeSource={RelativeSource AncestorType=ContentPresenter}, Converter={StaticResource converter}, Mode=OneWayToSource}" />
						</DataTemplate>
					</DataGridTemplateColumn.CellTemplate>											
				</DataGridTemplateColumn>
			</DataGrid.Columns>
			
		 </DataGrid>		
	 </Grid>
