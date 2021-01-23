       private void FEAdd_Click(object sender, EventArgs e)
       {
    
           var boxes = new List<TextBox>
           {
               MtrtextBox1,
               PltrtextBox11,
               BvtextBox12,
    
           };
    
           if (boxes.Any(tb => string.IsNullOrEmpty(tb.Text)))
           {
               MessageBox.Show("Fill required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               MtrtextBox1.BackColor = Color.Red;
               BvtextBox12.BackColor = Color.Red;
               return;
           }
           else if (dgvFE.Rows.Count > 0)		   
             {
            	 DateTime dt1 = DateTime.ParseExact(dgvFE.Rows[dgvFE.RowCount - 1].Cells[0].Value.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture); // careful about date formats.
                 DateTime dt2 = dateTimePicker1.Value.Date;
            	 
                 if(dt1>dt2)
            	 { 
            	     MessageBox.Show("Current bill date cannot be less than the previous bill date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                     return;
            	 }      
             }
          
    
               int n = dgvFE.Rows.Add();
               dgvFE.Rows[n].Cells[0].Value = dateTimePicker1.Value.ToString("dd-MM-yyyy");
               dgvFE.Rows[n].Cells[1].Value = MtrtextBox1.Text.ToString();
               dgvFE.Rows[n].Cells[3].Value = PltrtextBox11.Text.ToString();
               dgvFE.Rows[n].Cells[4].Value = BvtextBox12.Text.ToString();
    
    
               foreach (DataGridViewRow row in dgvFE.Rows)
               {
                   dgvFE.Rows[row.Index].Cells[2].Value = Math.Round((Double.Parse(dgvFE.Rows[row.Index].Cells[4].Value.ToString()) / Double.Parse(dgvFE.Rows[row.Index].Cells[3].Value.ToString())), 2).ToString();
    
                   if (n >= 1 && row.Index > 0)
                   {
                       dgvFE.Rows[row.Index - 1].Cells[5].Value = Math.Round((Double.Parse(dgvFE.Rows[row.Index].Cells[1].Value.ToString()) - Double.Parse(dgvFE.Rows[row.Index - 1].Cells[1].Value.ToString())), 2).ToString();
                       dgvFE.Rows[row.Index - 1].Cells[6].Value = Math.Round((Double.Parse(dgvFE.Rows[row.Index - 1].Cells[5].Value.ToString()) / Double.Parse(dgvFE.Rows[row.Index - 1].Cells[2].Value.ToString())), 2).ToString();
    
                   }
    
    
               }
               MtrtextBox1.Text = null;
               BvtextBox12.Text = null;
               MtrtextBox1.BackColor = Color.White;
               BvtextBox12.BackColor = Color.White;      
    
       }
       
