    public class Cell
    {
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
        public string Data { get; set; }
        public CellType CellType { get; set; } //you can also add an enum for CellType
    }
	<ItemsControl ItemsSource="{Binding AllCells}">
		<ItemsControl.ItemsPanel>
			<ItemsPanelTemplate>
				<Grid 
					v:GridHelper.ColumnsCount="{Binding TotalColumns}"
					v:GridHelper.RowsCount="{Binding TotalRows}">
				</Grid>
			</ItemsPanelTemplate>
		</ItemsControl.ItemsPanel>
		<ItemsControl.ItemContainerStyle>
			<Style TargetType="ContentPresenter">
				<Setter Property="Grid.Row" Value="{Binding Path=RowIndex}"/>
				<Setter Property="Grid.Column" Value="{Binding Path=ColumnIndex}"/>
			</Style>
		</ItemsControl.ItemContainerStyle>
	</ItemsControl>
