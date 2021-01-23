    public partial class Elev : Form
    {
    	private string category = null;
    
    	public Elev()
    	{
    		InitializeComponent();
    	}
    
        //Attached to **each** sub item in the dropdown
    	private void OnCategoryChecked(object sender, EventArgs e)
    	{
    		ToolStripMenuItem senderItem = sender as ToolStripMenuItem;
    
    		//If the sender isn't a tool strip item OR it's alreadt checked do nothing
    		if (senderItem != null && !senderItem.Checked)
    		{
    			//Un check the previously checked item
    			foreach (ToolStripMenuItem item in this.toolStripDropDownButton1.DropDownItems)
    			{
    				item.Checked = false;
    			}
    
    			//Set it to checked so the user knows which is selected
    			senderItem.Checked = true;
    
    			//Set the category
    			this.category = senderItem.Text;
    		}
    	}
    
    	private void ExamineButtonClicked(object sender, EventArgs e)
    	{
    		if (category == null)
    		{
    			MessageBox.Show("Select a category first!");
    		}
    		else
    		{
    			Simulare sim = new Simulare(this.category);
    			sim.Show();
    		}
    	}
    }
