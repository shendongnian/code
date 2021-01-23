    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace CSharpGUI {
    	public class WinFormExample : Form {
    		
    		private Button button;
    		
    		public WinFormExample() {
    			DisplayGUI();
    		}
    		
    		private void DisplayGUI() {
    			this.Name = "WinForm Example";
    			this.Text = "WinForm Example";
    			this.Size = new Size(150, 150);
    			this.StartPosition = FormStartPosition.CenterScreen;
    			
    			button = new Button();
    			button.Name = "button";
    			button.Text = "Click Me!";
    			button.Size = new Size(this.Width - 100, this.Height - 100);
    			button.Location = new Point(
    				(this.Width - button.Width) / 2 ,
    				(this.Height - button.Height) / 2);
    			button.Click += new System.EventHandler(this.MyButtonClick);
    			
    			this.Controls.Add(button);
    		}
    		
    		private void MyButtonClick(object source, EventArgs e) {
    			MessageBox.Show("My First WinForm Application");
    		}
    		
    		public static void Main(String[] args) {
    			Application.Run(new WinFormExample());
    		}
    	}
    }
