    private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.ColumnIndex == colRadioButton.Index && e.RowIndex >= 0)
        {
            e.PaintBackground(e.ClipBounds, true);
            
            // TODO: The radio button flickers on mouse over.
            // I tried setting DoubleBuffered on the parent panel, but the flickering persists.
            // If someone figures out how to resolve this, please leave a comment.
            Rectangle rectRadioButton = new Rectangle();
            // TODO: Would be nice to not use magic numbers here.
            rectRadioButton.Width = 14;
            rectRadioButton.Height = 14;
            rectRadioButton.X = e.CellBounds.X + (e.CellBounds.Width - rectRadioButton.Width) / 2;
            rectRadioButton.Y = e.CellBounds.Y + (e.CellBounds.Height - rectRadioButton.Height) / 2;
            ButtonState buttonState;
            if (e.Value == DBNull.Value || (bool)(e.Value) == false)
            {
                buttonState = ButtonState.Normal;
            }
            else
            {
                buttonState = ButtonState.Checked;
            }
            ControlPaint.DrawRadioButton(e.Graphics, rectRadioButton, buttonState);
            e.Paint(e.ClipBounds, DataGridViewPaintParts.Focus);
            e.Handled = true;
        }
    }
