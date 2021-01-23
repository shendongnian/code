                DateTime brithday;
                DataGridViewColumn col = new DataGridViewColumn();
                col.HeaderText = "Age";
                col.Name = "ageBoD";
                col.CellTemplate = new DataGridViewTextBoxCell();
                int column = dataGridViewX1.Columns.Count;
                dataGridViewX1.Columns.Insert(column, col);
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    brithday = (DateTime)dataGridViewX1[3, i].Value;
                    TimeSpan age = DateTime.Now - brithday;
                    dataGridViewX1[column, i].Value = age.Days / 365;
                }
