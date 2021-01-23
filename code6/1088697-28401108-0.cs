    for (int i = 0; i < d; ++i)
       for (int j = 0; j < d; j++)
       {
          labels[i*d+j] = new System.Windows.Forms.Label();
          labels[i*d+j].Size = new Size(50, 50);
          labels[i*d+j].Text = (k).ToString();
          labels[i*d+j].TabIndex = k++;
          labels[i*d+j].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
          table.Controls.Add(labels[i*d+j], j, i);
       }
