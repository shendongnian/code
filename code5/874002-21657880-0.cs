    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication4
    {
        public partial class Form1 : Form
        {
    	public Form1()
    	{
    	    InitializeComponent();
    
    	    CheckState state = checkBox1.CheckState;
    
    	    switch (state)
    	    {
    		case CheckState.Checked:
    		case CheckState.Indeterminate:
    		case CheckState.Unchecked:
    		    {
    			MessageBox.Show(state.ToString());
    			break;
    		    }
    	    }
    
    	    MessageBox.Show(checkBox1.Checked.ToString());
    	}
        }
    }
