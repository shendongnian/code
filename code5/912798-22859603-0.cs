    public class CustomGrid : Grid
    {
        protected override System.Windows.Size MeasureOverride(System.Windows.Size constraint)
        {
            //I assume Grid.MeasureOverride return the minimum size as desired size
            Size MinimumDesiredSize = base.MeasureOverride(constraint);
            //The remaining available space provided by the container
            double ConstraintWidthRemaining = constraint.Width - MinimumDesiredSize.Width;
            //The supposed remaining space if we assume than star columns width equals 0, will be calculated later
            double WidthRemaining = ConstraintWidthRemaining;
            //The width used in the remaining available space
            double WidthUsed = 0;
            //The number of column which are star sized
            double StarSum = 0;
            foreach (ColumnDefinition column in ColumnDefinitions.Where(c => c.Width.IsStar))
            {
                StarSum += column.Width.Value;
                WidthRemaining += column.MinWidth;
            }
            foreach (ColumnDefinition column in ColumnDefinitions.Where(c => c.Width.IsStar))
            {
                double Ratio = column.Width.Value / StarSum;
                double ColumnWidth = WidthRemaining * Ratio;
                if (column.MaxWidth != 0.0)
                {
                    if (ColumnWidth > column.MinWidth)
                    {
                        if (ColumnWidth <= column.MaxWidth)
                        {
                            WidthUsed += ColumnWidth - column.MinWidth;
                        }
                        else
                        {
                            WidthUsed += column.MaxWidth - column.MinWidth;
                        }
                    }
                }
                else
                {
                    WidthUsed += ColumnWidth - column.MinWidth;
                }
            }
            MinimumDesiredSize.Width += WidthUsed;
            return MinimumDesiredSize;
        }
    }
