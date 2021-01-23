    private void textBoxComment_KeyDown(object sender, KeyEventArgs e)
    {
        if ( e.Modifiers == Keys.Control )
        {
            switch(e.KeyCode)
            {
                case Keys.C:
                case Keys.X:
                case Keys.V:
                case Keys.Z:
                case Keys.I:
                case Keys.H:
                e.Handled = true;
                e.SuppressKeyPress = true;
                break;
                default:
                break;
            }
        }
    }
