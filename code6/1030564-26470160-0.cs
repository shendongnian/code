    public partial class Form1 : Form, IMessageFilter
    {
        ...
      
        public bool PreFilterMessage(ref Message m)
        {
            // If key is pressed or mouse is moved
            if (m.Msg == 0x0100 || m.Msg == 0x0200)
            {
                Application.RemoveMessageFilter(this);
                Application.Exit();
                return true;
            }
            return false;
        }
    }
