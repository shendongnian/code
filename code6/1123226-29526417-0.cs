    public partial class Spam_Scanner : Form
    {
        private Tester scan;
    
        private void testButton_Click(object sender, EventArgs e)
        { 
           scan = new Tester();
           ...
        }
    
        private void addButton_Click(object sender, EventArgs e)
        {
          scan.addSpam(Convert.ToString(addFlagBox.Text));
          ...
        }
    }
