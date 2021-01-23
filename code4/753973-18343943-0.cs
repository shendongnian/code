        Keys lastkey = Keys.None;
        Button b = new Button();
        private void KeyPress(object sender, KeyEventArgs e)
        {
            if (lastkey == Keys.Control)
            {
                //Do some stuff
                b.PerformClick();
            }
            if (e.KeyCode == Keys.Control)
                lastkey = Keys.Control;
            else
                lastkey = e.KeyCode;
        }
