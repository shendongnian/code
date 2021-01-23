    class MyView
    {
        public void CreateControl(string name)
        {
            Control picture = new UserControl1();
            picture.Visible = true;
            picture.Name = name;
            picture.Location = new Point(0, 0);
            picture.Show();
            flowLayoutPanel1.Controls.Add(picture);
    
            this.controls.Add(name, picture);
        }
    
        public void SetMsg(string name, msg)
        {
            ((UserControl1)this.controls[name]).SetMSG(msg);
        }
    
        private Dictionary<string, Control> controls = new Dictionary<string, Control>();
    }
