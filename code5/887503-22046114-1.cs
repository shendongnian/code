        internal sealed class DataGridViewTextButtonCell : DataGridViewCell
        {
            private const byte DATAGRIDVIEWTEXTBOXCELL_horizontalTextOffsetLeft = 3;
            private const byte DATAGRIDVIEWTEXTBOXCELL_horizontalTextOffsetRight = 4;
            private const byte DATAGRIDVIEWTEXTBOXCELL_horizontalTextMarginLeft = 0;
            private const byte DATAGRIDVIEWTEXTBOXCELL_horizontalTextMarginRight = 0;
            private const byte DATAGRIDVIEWTEXTBOXCELL_verticalTextOffsetTop = 2;
            private const byte DATAGRIDVIEWTEXTBOXCELL_verticalTextOffsetBottom = 1;
            private const byte DATAGRIDVIEWTEXTBOXCELL_verticalTextMarginTopWithWrapping = 1;
            private const byte DATAGRIDVIEWTEXTBOXCELL_verticalTextMarginTopWithoutWrapping = 2;
            private const byte DATAGRIDVIEWTEXTBOXCELL_verticalTextMarginBottom = 1;
            
            // Type of this cell's editing control
            private static readonly Type defaultEditType = typeof(DataGridViewTextButtonEditingControl);
            // Type of this cell's value. The formatted value type is string, the same as the base class DataGridViewTextBoxCell
            private static readonly Type defaultValueType = typeof(string);
            public override object Clone()
            {
                DataGridViewTextButtonCell cell = base.Clone() as DataGridViewTextButtonCell;
                if (cell != null)
                {
                    cell.ButtonClickHandler = ButtonClickHandler;
                }
                return cell;
            }
            /// <summary>
            /// Adjusts the location and size of the editing control given the alignment characteristics of the cell
            /// </summary>
            private Rectangle GetAdjustedEditingControlBounds(Rectangle editingControlBounds, DataGridViewCellStyle cellStyle)
            {
                // Add a 1 pixel padding on the left and right of the editing control
                editingControlBounds.X += 1;
                editingControlBounds.Width = Math.Max(0, editingControlBounds.Width - 2);
                // Adjust the vertical location of the editing control:
                int preferredHeight = cellStyle.Font.Height + 3;
                if (preferredHeight < editingControlBounds.Height)
                {
                    switch (cellStyle.Alignment)
                    {
                        case DataGridViewContentAlignment.MiddleLeft:
                        case DataGridViewContentAlignment.MiddleCenter:
                        case DataGridViewContentAlignment.MiddleRight:
                            editingControlBounds.Y += (editingControlBounds.Height - preferredHeight) / 2;
                            break;
                        case DataGridViewContentAlignment.BottomLeft:
                        case DataGridViewContentAlignment.BottomCenter:
                        case DataGridViewContentAlignment.BottomRight:
                            editingControlBounds.Y += editingControlBounds.Height - preferredHeight;
                            break;
                    }
                }
                return editingControlBounds;
            }
            public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
            {
                base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
                TextButton textButton = DataGridView.EditingControl as TextButton;
                if (textButton != null)
                {
                    //textButton.BorderStyle = BorderStyle.None;
                    string initialFormattedValueStr = initialFormattedValue as string;
                    textButton.Text = initialFormattedValueStr;
                    if (ButtonClickHandler != null)
                        textButton.ButtonClick += ButtonClickHandler;
                }
            }
            public override void DetachEditingControl()
            {
                base.DetachEditingControl();
                TextButton textButton = DataGridView.EditingControl as TextButton;
                if (textButton != null)
                {
                    textButton.ClearUndo();
                    if (ButtonClickHandler != null)
                        textButton.ButtonClick -= ButtonClickHandler;
                }
            }
            public override void PositionEditingControl(bool setLocation, bool setSize, Rectangle cellBounds, Rectangle cellClip, DataGridViewCellStyle cellStyle, bool singleVerticalBorderAdded, bool singleHorizontalBorderAdded, bool isFirstDisplayedColumn, bool isFirstDisplayedRow)
            {
                Rectangle editingControlBounds = PositionEditingPanel(cellBounds,
                                                            cellClip,
                                                            cellStyle,
                                                            singleVerticalBorderAdded,
                                                            singleHorizontalBorderAdded,
                                                            isFirstDisplayedColumn,
                                                            isFirstDisplayedRow);
                editingControlBounds = GetAdjustedEditingControlBounds(editingControlBounds, cellStyle);
                DataGridView.EditingControl.Location = new Point(editingControlBounds.X, editingControlBounds.Y);
                DataGridView.EditingControl.Size = new Size(editingControlBounds.Width, editingControlBounds.Height);
            }
            public DataGridViewTextButtonEditingControl EditingControl
            {
                get { return DataGridView == null ? null : DataGridView.EditingControl as DataGridViewTextButtonEditingControl; }
            }
            public override Type EditType
            {
                get { return defaultEditType; }
            }
            public override Type ValueType
            {
                get { return base.ValueType ?? defaultValueType; }
            }
            public override Type FormattedValueType
            {
                get { return defaultValueType; }
            }
            protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
            {
                if (DataGridView == null)
                {
                    return;
                }
                // First paint the borders and background of the cell.
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle,
                           paintParts & ~(DataGridViewPaintParts.ErrorIcon | DataGridViewPaintParts.ContentForeground));
                //if (PartPainted(paintParts, DataGridViewPaintParts.Border))
                //    PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
                Point ptCurrentCell = DataGridView.CurrentCellAddress;
                bool cellCurrent = ptCurrentCell.X == ColumnIndex && ptCurrentCell.Y == rowIndex;
                bool cellEdited = cellCurrent && DataGridView.EditingControl != null;
                // If the cell is in editing mode, there is nothing else to paint
                if (cellEdited)
                {
                    if (PartPainted(paintParts, DataGridViewPaintParts.Background))
                    {
                        //graphics.FillRectangle(br, cellBounds);
                        PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
                    }
                }
                else
                {
                    if (PartPainted(paintParts, DataGridViewPaintParts.ContentForeground))
                    {
                        // Take the borders into account
                        Rectangle borderWidths = BorderWidths(advancedBorderStyle);
                        Rectangle valBounds = cellBounds;
                        valBounds.Offset(borderWidths.X, borderWidths.Y);
                        valBounds.Width -= borderWidths.Right;
                        valBounds.Height -= borderWidths.Bottom;
                        // Also take the padding into account
                        if (cellStyle.Padding != Padding.Empty)
                        {
                            if (DataGridView.RightToLeft == RightToLeft.Yes)
                            {
                                valBounds.Offset(cellStyle.Padding.Right, cellStyle.Padding.Top);
                            }
                            else
                            {
                                valBounds.Offset(cellStyle.Padding.Left, cellStyle.Padding.Top);
                            }
                            valBounds.Width -= cellStyle.Padding.Horizontal;
                            valBounds.Height -= cellStyle.Padding.Vertical;
                        }
                        valBounds = GetAdjustedEditingControlBounds(valBounds, cellStyle);
                        TextFormatFlags horAlign = TextFormatFlags.Left;
                        switch (cellStyle.Alignment)
                        {
                            case DataGridViewContentAlignment.BottomLeft:
                            case DataGridViewContentAlignment.MiddleLeft:
                            case DataGridViewContentAlignment.TopLeft:
                                horAlign = TextFormatFlags.Left;
                                break;
                            case DataGridViewContentAlignment.BottomCenter:
                            case DataGridViewContentAlignment.MiddleCenter:
                            case DataGridViewContentAlignment.TopCenter:
                                horAlign = TextFormatFlags.HorizontalCenter;
                                break;
                            case DataGridViewContentAlignment.BottomRight:
                            case DataGridViewContentAlignment.MiddleRight:
                            case DataGridViewContentAlignment.TopRight:
                                horAlign = TextFormatFlags.Right;
                                break;
                        }
                        bool cellSelected = (cellState & DataGridViewElementStates.Selected) != 0;
                        SolidBrush br = new SolidBrush(cellSelected ? cellStyle.SelectionBackColor : cellStyle.BackColor);
                        if (PartPainted(paintParts, DataGridViewPaintParts.Background))
                        {
                            graphics.FillRectangle(br, cellBounds);
                            PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
                        }
                        if (cellStyle.Padding != Padding.Empty) 
                        { 
                            valBounds.Offset(cellStyle.Padding.Left, cellStyle.Padding.Top);
                            valBounds.Width -= cellStyle.Padding.Horizontal; 
                            valBounds.Height -= cellStyle.Padding.Vertical;
                        }
                        if (cellCurrent)
                        {
                            // Draw focus rectangle 
                            if (DataGridView.Focused && valBounds.Width > 0 && valBounds.Height > 0)
                            {
                                ControlPaint.DrawFocusRectangle(graphics, valBounds, Color.Empty, br.Color);
                            }
                        }
                        
                        int verticalTextMarginTop = cellStyle.WrapMode == DataGridViewTriState.True ? DATAGRIDVIEWTEXTBOXCELL_verticalTextMarginTopWithWrapping : DATAGRIDVIEWTEXTBOXCELL_verticalTextMarginTopWithoutWrapping;
                        valBounds.Offset(DATAGRIDVIEWTEXTBOXCELL_horizontalTextMarginLeft, verticalTextMarginTop);
                        valBounds.Width -= DATAGRIDVIEWTEXTBOXCELL_horizontalTextMarginLeft + DATAGRIDVIEWTEXTBOXCELL_horizontalTextMarginRight;
                        valBounds.Height -= verticalTextMarginTop + DATAGRIDVIEWTEXTBOXCELL_verticalTextMarginBottom;
                        
                        TextRenderer.DrawText(graphics, formattedValue as string, cellStyle.Font,
                                              valBounds,
                                              cellSelected ? cellStyle.SelectionForeColor : cellStyle.ForeColor, TextFormatFlags.Default | horAlign | TextFormatFlags.Top);
                    }
                    if (PartPainted(paintParts, DataGridViewPaintParts.ErrorIcon))
                    {
                        // Paint the potential error icon on top of the NumericUpDown control
                        base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText,
                                   cellStyle, advancedBorderStyle, DataGridViewPaintParts.ErrorIcon);
                    }
                }
            }
            /// <summary>
            /// Little utility function called by the Paint function to see if a particular part needs to be painted. 
            /// </summary>
            private static bool PartPainted(DataGridViewPaintParts paintParts, DataGridViewPaintParts paintPart)
            {
                return (paintParts & paintPart) != 0;
            }
            public EventHandler<TextButton.TextButtonEventArgs> ButtonClickHandler { get; set; }
        }
