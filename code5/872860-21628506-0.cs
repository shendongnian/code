        bool _focus;
        private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                _focus = true;
        }
        private void button1_KeyUp(object sender, KeyEventArgs e)
        {
            _focus = false;
        }
        private void button1_Leave(object sender, EventArgs e)
        {
            if(_focus)
                button1.Focus(); // or (sender as Control)
        }
