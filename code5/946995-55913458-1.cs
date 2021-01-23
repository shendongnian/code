    using System.Windows.Forms;
    Cursor storedCursor = null;
    
    private void TextBox_KeyPress(object sender, KeyPressEventArgs e)        
    {
        storedCursor = Cursor.Current;
    }
    
    private void TextBox_TextChanged(object sender, EventArgs e)
    {
        if(Cursor.Current == null)
        {
            Cursor.Current = storedCursor;
        }
    }
