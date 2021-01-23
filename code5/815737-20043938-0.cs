     factory.SetValue(Image.StretchProperty, Stretch.UniformToFill);
     var cellTemplate = new DataTemplate() { VisualTree = factory };
     cellTemplate.LoadContent();
     column.CellTemplate = cellTemplate;
     this.gridView.Columns.Add(column);
