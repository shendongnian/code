     public class AutoColumnGrid : Grid
    {
        protected override void OnVisualChildrenChanged(System.Windows.DependencyObject visualAdded, System.Windows.DependencyObject visualRemoved)
        {
            //Checking VisualAdded if it is not null than adding child to Grid
            if (visualAdded != null)
            {
                // Getting column definition count
                int columnDefinitionCount = this.ColumnDefinitions.Count;
                // Getting child from last, because adds to last
                var child = this.Children[columnDefinitionCount];
                // Adding new ColumnDefinition
                this.ColumnDefinitions.Add(new ColumnDefinition());
                // Setting column to child
                Grid.SetColumn(child, columnDefinitionCount);
            }//Checking VisualRemoved if it is not null than child from Grid
            else if (visualRemoved != null)
            {
                int columnDefinitionIndex = Grid.GetColumn(visualRemoved as UIElement);
                this.ColumnDefinitions.RemoveAt(columnDefinitionIndex);
            }
            Application.Current.MainWindow.Dispatcher.BeginInvoke(new Action(SetColumnWidth));
        }
        /// <summary>
        /// Setts Width to each column
        /// if Grid content bigger than window than sets width in percent else if Grid content less than window sets to auto
        /// </summary>
        private void SetColumnWidth()
        {
            for (int index = 0; index < this.ColumnDefinitions.Count; index++)
            {
                var gridActualWidth = this.ActualWidth;
                // Getting Grids width
                this.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                var gridDesiredSize = Convert.ToInt16(this.DesiredSize.Width);
                //calculating nesseseryAreaPercent
                var nesseseryAreaPercent = gridDesiredSize / gridActualWidth * 100;
                //setting column index to child
                var child = this.Children[index];
                Grid.SetColumn(child, index);
                // if  nesseseryAreaPercent less or equal 100%, it means grid content is less than grids width and we setting to auto
                if (nesseseryAreaPercent <= 100)
                {
                    this.ColumnDefinitions[index].Width = GridLength.Auto;
                }
                else
                { // Else setting with persent
                    child.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                    int columnWidth = Convert.ToInt16(child.DesiredSize.Width);
                    this.ColumnDefinitions[index].Width = new GridLength(columnWidth, GridUnitType.Star);
                }
            }
        }
    }
