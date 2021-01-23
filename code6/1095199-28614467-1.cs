        private void GridSplitter_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            if (e.VerticalChange > 1500 || e.VerticalChange > -15000) return;
            if (e.VerticalChange > 0 || Visibility.Visible.Equals(MainScrollViewer.ComputedVerticalScrollBarVisibility))
            {
                this.MainGrid.Height = this.MainGrid.ActualHeight + e.VerticalChange;
            }
            e.Handled = true;
        }
