        grid.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                    {
                        ValueType = typeof (string),
                        HeaderText = "Name"
                    },
                new DataGridViewTextButtonColumn
                    {
                        ValueType = typeof (int),
                        HeaderText = "Count",
                        ButtonClickHandler = (o, e) =>
                            {
                                grid.EndEdit();
                                using (EditForm frm = new EditForm { Value = e.Text })
                                    if (frm.ShowDialog(this) == DialogResult.OK)
                                    {
                                        e.Text = frm.Value;
                                        e.Handled = true;
                                    }
                                grid.BeginEdit(false);
                            }
                    }
            });
