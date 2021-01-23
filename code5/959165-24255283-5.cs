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
            if (tileBuyPlayer2.Checked && ownerShipsPlayer2.peacockOwner == false && keyAPressed == true)
            {
                // do this sorry not on here cause how big it is
            }
        }
        private void mainForm_KeyUp(object sender, KeyEventArgs e)
        {
            keyAPressed = false;
        }
    }
