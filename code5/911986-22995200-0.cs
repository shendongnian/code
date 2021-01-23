    System.Windows.Controls.Primitives.DataGridColumnHeader headerObj;
    headerObj = GetColumnHeaderFromColumn(myDataGrid, myDataGrid.Columns[1].Header);
    System.Windows.Automation.Peers.DataGridColumnHeaderAutomationPeer peer =
                                    new DataGridColumnHeaderAutomationPeer(headerObj);
                                IInvokeProvider invoker = (IInvokeProvider)peer;
                                invoker.Invoke(); // Invoke a click programmatically   
        private System.Windows.Controls.Primitives.DataGridColumnHeader GetColumnHeaderFromColumn(DependencyObject parent, object header)
        {            
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child != null)
                {
                    if (child is System.Windows.Controls.Primitives.DataGridColumnHeader)
                    {
                        System.Windows.Controls.Primitives.DataGridColumnHeader columnHeader = child as System.Windows.Controls.Primitives.DataGridColumnHeader;
                        if (header.Equals(columnHeader.Content))
                        {
                            return columnHeader;
                        }
                    }
                    else
                    {
                        System.Windows.Controls.Primitives.DataGridColumnHeader columnHeader = GetColumnHeaderFromColumn(child, header);
                        if (null != columnHeader)
                        {
                            return columnHeader;
                        }
                    }
                }
            }
            return null;
        }
    
