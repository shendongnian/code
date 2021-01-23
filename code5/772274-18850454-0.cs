        private void Form1_Resize(object sender, EventArgs e) //form resize event
        {
          grdView1.SetBounds(Left,Top, this.Width-10,this.Height-10);
          grdView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
          grdView1.Columns[0].FillWeight = 45;
          //same for other columns according to your requirments.
         
        }
