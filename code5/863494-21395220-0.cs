        this.gridGroupingControl1.TableControlMouseDown += gridGroupingControl1_TableControlMouseDown;
        private string rightClickCol;
        void gridGroupingControl1_TableControlMouseDown(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlMouseEventArgs e)
        {
            if (e.Inner.Button == System.Windows.Forms.MouseButtons.Right)
            {
                rightClickCol = string.Empty;
                Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor columnDescriptor = 
                    gridGroupingControl1.TableControl.GetHeaderColumnDescriptorAt(e.Inner.Location);
                if (columnDescriptor != null)
                    rightClickCol = columnDescriptor.Name;
            }
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(rightClickCol))
            {
                hideColumnToolStripMenuItem.Text = "Hide " + rightClickCol;
                hideColumnToolStripMenuItem.Enabled = true;
            }
            else
            {
                hideColumnToolStripMenuItem.Text = "Hide Column";
                hideColumnToolStripMenuItem.Enabled = false;
            }
        }
        private void hideColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rightClickCol))
                gridGroupingControl1.TableDescriptor.VisibleColumns.Remove(rightClickCol);
        }
