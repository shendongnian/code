        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.globalLabel1 = new Label();
            this.globalLabel1.Text = this.listBox1.SelectedItem.ToString() + " : ";
            //other label properties like, tag, name, events, font etc.
        }
      
        private void listBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.globalLabel1 != null)
            {
               
                this.globalLabel1.Show();
                this.lPanel.SendToBack();
                this.lPanel.Controls.Add(globalLabel1);
            }
        }
        //////////////////////////USE PANEL_MOVEUP EVENT//////////////
        private void lPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.globalLabel1 != null)
            {
                this.globalLabel1.Left = System.Windows.Forms.Cursor.Position.X-50 // Change
                    - this.Location.X;
                this.globalLabel1.Top = System.Windows.Forms.Cursor.Position.Y-100 //Change
                    - this.Location.Y;
                this.globalLabel1.Show();
                this.lPanel.SendToBack();
            }
        }
