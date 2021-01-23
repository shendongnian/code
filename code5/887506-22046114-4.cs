        internal class DataGridViewTextButtonEditingControl : TextButton, IDataGridViewEditingControl
        {
            public DataGridViewTextButtonEditingControl()
            {
                InnerTextBox.TextChanged += (o, e) => NotifyDataGridViewOfValueChange();
            }
            public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
            {
                Font = dataGridViewCellStyle.Font;
                if (dataGridViewCellStyle.BackColor.A < 255)
                {
                    Color opaqueBackColor = Color.FromArgb(255, dataGridViewCellStyle.BackColor);
                    BackColor = opaqueBackColor;
                    EditingControlDataGridView.EditingPanel.BackColor = opaqueBackColor;
                }
                else
                {
                    BackColor = dataGridViewCellStyle.BackColor;
                }
                ForeColor = dataGridViewCellStyle.ForeColor;
            }
            public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
            {
                TextBox textBox = InnerTextBox;
                switch (keyData & Keys.KeyCode)
                {
                    case Keys.Right:
                        {
                            if (textBox != null)
                            {
                                // If the end of the selection is at the end of the string,
                                // let the DataGridView treat the key message
                                if ((RightToLeft == RightToLeft.No && !(textBox.SelectionLength == 0 && textBox.SelectionStart == textBox.Text.Length)) ||
                                    (RightToLeft == RightToLeft.Yes && !(textBox.SelectionLength == 0 && textBox.SelectionStart == 0)))
                                {
                                    return true;
                                }
                            }
                            break;
                        }
                    case Keys.Left:
                        {
                            if (textBox != null)
                            {
                                // If the end of the selection is at the begining of the string
                                // or if the entire text is selected and we did not start editing,
                                // send this character to the dataGridView, else process the key message
                                if ((RightToLeft == RightToLeft.No && !(textBox.SelectionLength == 0 && textBox.SelectionStart == 0)) ||
                                    (RightToLeft == RightToLeft.Yes && !(textBox.SelectionLength == 0 && textBox.SelectionStart == textBox.Text.Length)))
                                {
                                    return true;
                                }
                            }
                            break;
                        }
                    case Keys.Home:
                    case Keys.End:
                        {
                            // Let the grid handle the key if the entire text is selected.
                            if (textBox != null)
                            {
                                if (textBox.SelectionLength != textBox.Text.Length)
                                {
                                    return true;
                                }
                            }
                            break;
                        }
                    case Keys.Delete:
                        {
                            // Let the grid handle the key if the carret is at the end of the text.
                            if (textBox != null)
                            {
                                if (textBox.SelectionLength > 0 ||
                                    textBox.SelectionStart < textBox.Text.Length)
                                {
                                    return true;
                                }
                            }
                            break;
                        }
                }
                return !dataGridViewWantsInputKey;
            }
            public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
            {
                return Text; // Convert.ChangeType(Text, typeof(int));
            }
            public void PrepareEditingControlForEdit(bool selectAll)
            {
                if (selectAll)
                {
                    InnerTextBox.SelectAll();
                }
                else
                {
                    // Do not select all the text, but
                    // position the caret at the end of the text
                    InnerTextBox.SelectionStart = InnerTextBox.Text.Length;
                }
            }
            public DataGridView EditingControlDataGridView { get; set; }
            public object EditingControlFormattedValue { get; set; }
            public int EditingControlRowIndex { get; set; }
            public bool EditingControlValueChanged { get; set; }
            public Cursor EditingPanelCursor { get; private set; }
            public bool RepositionEditingControlOnValueChange { get; private set; }
            protected override void OnTextChanged(EventArgs e)
            {
                base.OnTextChanged(e);
                NotifyDataGridViewOfValueChange();
            }
            private void NotifyDataGridViewOfValueChange()
            {
                if (!EditingControlValueChanged)
                {
                    EditingControlValueChanged = true;
                    EditingControlDataGridView.NotifyCurrentCellDirty(true);
                }
            }
        }
