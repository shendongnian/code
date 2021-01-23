    public class DetectActivityMessageFilter : IMessageFilter
    {
        private const int WM_LBUTTONDOWN = 0x0201;
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN)
            {
                // The left mouse button was pressed
            }
            return false;
        }
    }
