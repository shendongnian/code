    <GridViewColumn Header="TestColumn">
		<GridViewColumn.CellTemplate>
			<DataTemplate>
				<ContentPresenter Content="{Binding TestProperty}" ContentTemplate="{StaticResource GridViewTextCell}" />
			</DataTemplate>
		</GridViewColumn.CellTemplate>
	</GridViewColumn>
