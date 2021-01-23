    public partial class Form1 : Form
    {
        const int KL_NAMELENGTH = 9;
    
        [DllImport("user32.dll")]
        private static extern long GetKeyboardLayoutName(
              System.Text.StringBuilder pwszKLID);
    
    private void Form1_Load(object sender, EventArgs e)
        {
    		StringBuilder name = new StringBuilder(KL_NAMELENGTH);
            GetKeyboardLayoutName(name);
            String KeyBoardLayout = name.ToString();
    		if (KeyBoardLayout == "00000407" || KeyBoardLayout == "00000807")
    		{
    			MessageBox.Show("Using QWERTZ");
    		}
    		else if (KeyBoardLayout == "0000040c" || KeyBoardLayout == "0000080c")
    		{
    			MessageBox.Show("Using AZERTY");
    		}
    		else if (KeyBoardLayout == "00010409")
    		{
    			MessageBox.Show("Using Dvorak");
    		}
    		else
    		{
    			MessageBox.Show("Using QWERTY");
    		}
    	}	
    }
