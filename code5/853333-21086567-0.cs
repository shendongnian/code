    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication
    {
    	public partial class Form1 : Form
    	{
    		private CheckBox checkBox;
    		private Button button;
    
    		public Form1()
    		{
    			InitializeComponent();
    
    			checkBox = new CheckBox();
    			checkBox.Left = 12;
    			checkBox.Top = 41;
    			Controls.Add(checkBox);
    
    			button = new Button();
    			button.Left = 12;
    			button.Top = 64;
    			button.Text = "Action";
    			Controls.Add(button);
    
    			button.DataBindings.Add("Enabled", checkBox, "Checked");
    		}
    	}
    }
