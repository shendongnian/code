	foreach (DataColumn cc in table.Columns)
	{
		Type type = cc.DataType;
		Style alignStyle = new Style(typeof(Microsoft.Windows.Controls.DataGridCell));                            
		alignStyle.Setters.Add(new Setter(Microsoft.Windows.Controls.DataGridCell.VerticalAlignmentProperty, VerticalAlignment.Center));
		var column = new Microsoft.Windows.Controls.DataGridTextColumn
		{
			Header = cc.ColumnName,
			Binding = new Binding(cc.ColumnName)
		};
		if(type.Name=="Int32"){
			alignStyle.Setters.Add(new Setter(TextBlock.TextAlignmentProperty, TextAlignment.Right));
			column.Foreground = Brushes.Red;
			column.CellStyle = alignStyle;
		}
		else if (type.Name == "DateTime")
		{
			alignStyle.Setters.Add(new Setter(TextBlock.TextAlignmentProperty, TextAlignment.Center));
			column.Foreground = Brushes.Green;
			column.Binding.StringFormat = "{0:dd.MM.yyyy}";
			column.CellStyle = alignStyle;
		}
		else if (type.Name == "String")
		{
			alignStyle.Setters.Add(new Setter(TextBlock.TextAlignmentProperty, TextAlignment.Left));
			column.Foreground = Brushes.Blue;
			column.CellStyle = alignStyle;
		}
		else if (type.Name == "Double")
		{
			alignStyle.Setters.Add(new Setter(TextBlock.TextAlignmentProperty, TextAlignment.Right));
			column.Foreground = Brushes.Brown;
			column.Binding.StringFormat = "{0:F3}";
			column.CellStyle = alignStyle;
		}
		grids.Columns.Add(column);
	}
