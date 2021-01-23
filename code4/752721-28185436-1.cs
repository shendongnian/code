     for (int i = 0; i < GridView1.Rows.Count; i++) {
         if (i % 2 == 0) {
           GridView1.Rows[i].Cells[0].Style.BackColor = System.Drawing.Color.Green;
           GridView1.Rows[i].Cells[1].Style.BackColor = System.Drawing.Color.Green;
         }
         else {
           GridView1.Rows[i].Cells[0].Style.BackColor = System.Drawing.Color.Red;
           GridView1.Rows[i].Cells[1].Style.BackColor = System.Drawing.Color.Red;
         }
    }
