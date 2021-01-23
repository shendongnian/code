    <DataTemplate x:Key="commonTemplate">
		<Label Content="{Binding}" />
	</DataTemplate>
    
    <GridViewColumn>
		<GridViewColumn.CellTemplate>
			<DataTemplate>
				<ContentPresenter Content="{Binding Name}"
					ContentTemplate="{StaticResource commonTemplate}"/>
			</DataTemplate>
		</GridViewColumn.CellTemplate>
	</GridViewColumn>
        
    <GridViewColumn>
		<GridViewColumn.CellTemplate>
			<DataTemplate>
				<ContentPresenter Content="{Binding Date}"
					ContentTemplate="{StaticResource commonTemplate}"/>
			</DataTemplate>
		</GridViewColumn.CellTemplate>
	</GridViewColumn>
