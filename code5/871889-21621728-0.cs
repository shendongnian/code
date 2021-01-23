    private void dg_PreviewKeyDown(object sender, KeyEventArgs e)
            {
               
                    if (e.Key == Key.Enter)
                    {
                        DataGridRow rowContainer = (DataGridRow)BomPickerGrid.ItemContainerGenerator.ContainerFromItem(UCItems[gridIndex+1]);
                        if (rowContainer != null)
                        {
                            DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(rowContainer);
                            int columnIndex = BomPickerGrid.Columns.IndexOf(BomPickerGrid.CurrentColumn);
                            DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex);
                            TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Last);
       /* FocusNavigationDirection.Last is used because the 
    TextBox I want to focus on is the Last control in that Cell*/
                                    request.Wrapped = true;
                                    cell.MoveFocus(request);
                                    rowContainer = (DataGridRow)BomPickerGrid.ItemContainerGenerator.ContainerFromItem(BomPickerGrid.CurrentItem);
                                    BomPickerGrid.SelectedItem = BomPickerGrid.CurrentItem;
                                    e.Handled = true;
                                    BomPickerGrid.UpdateLayout();
                                }
                            }
