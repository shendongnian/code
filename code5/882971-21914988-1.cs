        private void panel1_MouseEnter(object sender, System.EventArgs e) 
        {
            MyUserControl mcu = new MyUserControl ();
            this.popup =mcu; //save references to new control
            this.popup.Location.X = ((Control)sender).Location.X+ offsetX; 
            this.popup.Location.Y = ((Control)sender).Location.Y+ offsetY;
            this.Controls.Add(this.popup);
            
        }
       
        private void panel1_MouseLeave(object sender, System.EventArgs e) 
        {
            this.Controls.Remove(this.popup);
        }
