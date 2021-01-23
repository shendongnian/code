    // call this before Application.Run():
    Application.AddMessageFilter(new WmInputLangChangeRequestFilter());
    class WmInputLangChangeRequestFilter : IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x0050)
            {
                return (long)m.LParam > 0x7FFFFFFF;
            }
            return false;
        }
    }
