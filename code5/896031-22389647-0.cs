      if (text != null && (paint && !flag2 || computeContentBounds))
      {
        int y = cellStyle.WrapMode == DataGridViewTriState.True ? 1 : 2;
        rectangle3.Offset(0, y);
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Rectangle& local = @rectangle3;
        // ISSUE: explicit reference operation
        int width = (^local).Width;
        // ISSUE: explicit reference operation
        (^local).Width = width;
        rectangle3.Height -= y + 1;
        if (rectangle3.Width > 0 && rectangle3.Height > 0)
        {
          TextFormatFlags cellStyleAlignment = DataGridViewUtilities.ComputeTextFormatFlagsForCellStyleAlignment(this.DataGridView.RightToLeftInternal, cellStyle.Alignment, cellStyle.WrapMode);
          if (paint)
          {
            if (DataGridViewCell.PaintContentForeground(paintParts))
            {
              if ((cellStyleAlignment & TextFormatFlags.SingleLine) != TextFormatFlags.Default)
                cellStyleAlignment |= TextFormatFlags.EndEllipsis;
              TextRenderer.DrawText((IDeviceContext) graphics, text, cellStyle.Font, rectangle3, flag3 ? cellStyle.SelectionForeColor : cellStyle.ForeColor, cellStyleAlignment);
            }
          }
          else
            rectangle1 = DataGridViewUtilities.GetTextBounds(rectangle3, text, cellStyleAlignment, cellStyle);
        }
