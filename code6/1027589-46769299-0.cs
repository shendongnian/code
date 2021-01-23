        protected override void Paint(Graphics graphics, Rectangle clipBounds,
        Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState,
        object value, object formattedValue, string errorText,
        DataGridViewCellStyle cellStyle,
        DataGridViewAdvancedBorderStyle advancedBorderStyle,
        DataGridViewPaintParts paintParts)
        {
            // Paint the base content
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState,
               value, formattedValue, errorText, cellStyle,
               advancedBorderStyle, paintParts);
            if (this.Image != null)
            {
                // Draw the image clipped to the cell.
                System.Drawing.Drawing2D.GraphicsContainer container =
                graphics.BeginContainer();
                graphics.SetClip(cellBounds);
                // ====> Recalculate Location to have a Middle alignment
                int verticalPosition = cellBounds.Y + ( (cellBounds.Height/2) - (this.Image.Height/2) );
                cellBounds.Location = new Point(cellBounds.X, verticalPosition);
                
                graphics.DrawImageUnscaled(this.Image, cellBounds.Location);
                
                graphics.EndContainer(container);
                
            }
        }
