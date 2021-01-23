    var Decade1Hours = new DataGridViewTextBoxColumn()
    {
       Name = "Decade1Hours",
       Width = 50,
       DataPropertyName = "Decade1Hours",
       ReadOnly = true,
       DefaultCellStyle = new DataGridViewCellStyle()
           {
            Alignment = DataGridViewContentAlignment.MiddleCenter,
            ForeColor = System.Drawing.Color.Black,
            Font = new Font(font, FontStyle.Bold),
            Format = "n2"
          },
       HeaderCell = new DataGridViewColumnHeaderCell()
          {
              Style = new DataGridViewCellStyle()
                   {
                     Alignment = DataGridViewContentAlignment.MiddleCenter,
                     BackColor = System.Drawing.Color.Blue
                   }
           }
    };
    Decade1Hours.HeaderText = "Дек.1";
    dgvTrucksMaster.Columns.Add(Decade1Hours);
