    public class Form10 : Form {
    	Button btn = new Button { Text = "Button", Location = new Point(100, 100) };
    	Panel border = new Panel { Dock = DockStyle.Fill, BorderStyle = BorderStyle.Fixed3D };
    
    	public Form10() {
    		Controls.Add(border);
    		border.Controls.Add(btn);
    
    		btn.Click += delegate {
    			if (border.BorderStyle == BorderStyle.Fixed3D) {
    				border.BorderStyle = BorderStyle.None;
    				border.Parent.Padding = new Padding(2);
    			}
    			else {
    				border.BorderStyle = BorderStyle.Fixed3D;
    				border.Parent.Padding = new Padding(0);
    			}
    
    		};
    	}
    }
