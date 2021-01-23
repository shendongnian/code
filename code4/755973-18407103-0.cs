        private volatile bool m_SpaceDepressed;
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                // Set Flag
                m_SpaceDepressed = true;
            }
        }
        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                // UnSet Flag
                m_SpaceDepressed = false;
            }
        }
