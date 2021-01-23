     var dg = productFilterResult.ProductsGrid;
                    for (int i = 0; i < dg.Items.Count; i++)
                    {
                        DataGridRow row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromIndex(i);
                        var cellContent = dg.Columns[1].GetCellContent(row);
                        var cellContentPresenter = (ContentPresenter)cellContent;
                        DataTemplate editingTemplate = cellContentPresenter.ContentTemplate;
                        TextBlock CellTextBox = editingTemplate.FindName("IndexCell", cellContentPresenter) as TextBlock;
                        string CellValue = CellTextBox.Text;
                        var BindedModel = cellContentPresenter.Content;
                    }
