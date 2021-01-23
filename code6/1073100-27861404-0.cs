    //grid.CurrentCellDirtyStateChanged += grid_CurrentCellDirtyStateChanged;
            void grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
            {
                if (grid.IsCurrentCellDirty)
                {
                    var cell = grid.CurrentCell;
                    if (cell is DataGridViewCheckBoxCell)
                    {
                        grid.EndEdit();
                        //you could catch the cellvaluechanged event (or a bound listchanged event), or handle the change immediately here, e.g.:
                        //Console.WriteLine("{0} value changed to {1}", cell.OwningColumn.HeaderText, cell.Value);
                    }
                }
            }
