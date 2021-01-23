    private Label label;  
    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (this.label == null)   
        {
            label = new Label(); 
            label.Name = "customLabel";
            label.AutoSize = true;
            label.Text = "Dynamically Generated Label";
            label.Location = new Point(50, 50);
            label.BringToFront();
        }
        
        if (checkBox1.Checked)
        {
            this.Controls.Add(label);
        }
        else if(label != null && this.Controls.Contains(label))
        {
           
           this.Controls.Remove(label);            
        }
    }
