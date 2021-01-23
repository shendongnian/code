     DataGridView[] rtb = new DataGridView[100];
                 for (int i = 0; i < 1; i++)
                 {
                                    //Start Gridview
                     rtb[i] = new System.Windows.Forms.DataGridView();
                     rtb[i].Location = new System.Drawing.Point(0, 50);
                     rtb[i].Size = new System.Drawing.Size(1020, 150);
                     //ID Column
                     rtb[i].Columns.Add("tr_id", "ID");
                     rtb[i].Columns["tr_id"].ReadOnly = true;
                     rtb[i].Columns["tr_id"].Width = 1;
                     rtb[i].KeyDown += new KeyEventHandler(xKeyEvent);
                     this.Controls.Add(rtb[i]);
                 }
