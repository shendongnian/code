    public class DemoClass
    {
        public static Boolean keyPressed = false;
        
        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {                
            if (e.KeyData == Keys.A)
            {
                MessageBox.Show(" just for debugging ");
                keyPressed = true;
            } 
            else 
            {
                keyPressed = false;
            }
            if (keyPressed == true)
            {
                // Reset keyPressed to false
                keyPressed = false
                if (tileBuyPlayer2.Checked && ownerShipsPlayer2.peacockOwner == false)
                {
                    // do this sorry not on here cause how big it is
                }
            }
        }
    }
