    public class DemoClass
    {
        public static Boolean keyAPressed = false;
        
        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {                
            if (e.KeyCode == Keys.A)
            {
                MessageBox.Show(" just for debugging ");
                keyAPressed = true;
            } 
            else 
            {
                keyAPressed = false;
            }
            if (keyAPressed == true)
            {
                // Reset keyAPressed to false
                keyAPressed = false
                if (tileBuyPlayer2.Checked && ownerShipsPlayer2.peacockOwner == false)
                {
                    // do this sorry not on here cause how big it is
                }
            }
        }
    }
