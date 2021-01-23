     /// <summary>
        /// Resets the sorting.
        /// </summary>
        public void ResetSorting()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(dgVATINS.ItemsSource); // Gets the default view of the DataGrid
            if (view != null && view.SortDescriptions.Count > 0)
            {
                view.SortDescriptions.Clear(); // Clears the sorting
                foreach (DataGridColumn column in dgVATINS.Columns)
                {
                    column.SortDirection = null;
                };
            }
        }
