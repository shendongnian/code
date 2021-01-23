      bool m_BackPressed = false;
        private void ChildAge_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (!m_BackPressed)            
            {
                if (!int.TryParse(ChildAge.Text, out i))
                {
                    MessageBox.Show("Plaese enter a valid Age");
                } 
            }
            
        }
        private void ChildAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            m_BackPressed = (e.KeyChar.Equals((char)Keys.Back)) ? true : false;
        }
