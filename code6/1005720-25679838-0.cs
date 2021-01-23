    class Form4 : Form {
    
    	PictureBox pb = new PictureBox() { BackColor = Color.RosyBrown, Dock = DockStyle.Fill };
    	Label lb = new Label { Text = "Label", AutoSize = true };
    	TableLayoutPanel panel = new TableLayoutPanel { Dock = DockStyle.Fill };
    	public Form4() {
    		Controls.Add(panel);
    		panel.Controls.Add(lb, 0, 0);
    		panel.Controls.Add(pb, 1, 0);
    	}
    }
