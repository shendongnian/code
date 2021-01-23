     private void Form1_Load(object sender, EventArgs e)
     {
            //trying to draw NxM table 
            //where N is horizontal cell count M is vertical cell count
            Table tbl = new Table();
            var pictureBoxes = tbl.Tablenm(9, 9)
            foreach (var pictureBox in pictureBoxes)
            {
              Controls.Add(picturebox)}
            }
     }
