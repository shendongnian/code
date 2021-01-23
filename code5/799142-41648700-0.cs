            this.Size = new Size(750, 450);
            data.Size = new Size(700, 200);
            data.Location = new Point(5, 40);
            string[] raw_text = System.IO.File.ReadAllLines("Etudiant.txt");
            string[] data_col = null;
            int x = 0;
            foreach (string text_line in raw_text) {
                //MessageBox.Show(text_line);
                data_col = text_line.Split('|');
                if (x == 0){
                    //header
                    for (int i=0; i <= data_col.Length - 1; i++) {
                        table.Columns.Add(data_col[i]);
                    }
                    x++;
                }
                else {
                    //data
                    table.Rows.Add(data_col);
                }
            }
            data.DataSource = table;
            this.Controls.Add(data);
