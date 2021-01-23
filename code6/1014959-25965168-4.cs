            for (int i = 0; i < dgv_Fields.Rows.Count; i++)
            {
                // Add a key field column that has NOT been selected to a column
                if (Convert.ToBoolean(dgv_Fields.Rows[i].Cells[0].Value) ||
                    (Convert.ToInt32(dgv_Fields.Rows[i].Cells["Key#"].Value) > 0 &&
                    !Convert.ToBoolean(dgv_Fields.Rows[i].Cells[0].Value)))
                {
                    dgv_columns.ColumnCount = count + 1;
                    cName = FirstLetterToUpper(dgv_Fields.Rows[i].Cells[1].Value.ToString());
                    dgv_columns.Columns[count].Name = dgv_Fields.Rows[i].Cells[1].Value.ToString();
                    if (Convert.ToInt32(dgv_Fields.Rows[i].Cells["Key#"].Value) > 0)
                        dgv_columns.Columns[count].Tag = dgv_Fields.Rows[i].Cells["Key#"].Value;
                    else
                        dgv_columns.Columns[count].Tag = "";
                    if ((Convert.ToInt32(dgv_Fields.Rows[i].Cells["Key#"].Value) > 0 &&
                    !Convert.ToBoolean(dgv_Fields.Rows[i].Cells[0].Value)))
                        dgv_columns.Columns[count].Name = "*" + dgv_Fields.Rows[i].Cells[1].Value.ToString();
                    tbx = x + 160;
                    label = new Label();
                    label.Name = "l" + count.ToString();
                    label.Text = cName.PadRight(25);
                    if ((Convert.ToInt32(dgv_Fields.Rows[i].Cells["Key#"].Value) > 0 &&
                    !Convert.ToBoolean(dgv_Fields.Rows[i].Cells[0].Value)))
                        label.Text = "*" + cName.PadRight(25);
                    label.Location = new Point(x, y);
                    label.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                    label.AutoSize = true;
                    panel1.Controls.Add(label);
                    richtextbox = new RichTextBox();
                    richtextbox.Name = "rtb" + count.ToString();
                    richtextbox.Location = new Point(tbx + 10, y - 4);
                    richtextbox.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                    richtextbox.Size = new Size(100, 35);
                    richtextbox.Tag = count.ToString();
                    richtextbox.Click += new EventHandler(richtextbox_Click);
                    richtextbox.TextChanged += new EventHandler(richtextbox_TextChanged);
                    panel1.Controls.Add(richtextbox);
                    y += 40;
                    count++;
                }
            }
