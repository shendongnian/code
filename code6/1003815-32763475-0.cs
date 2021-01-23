    class WmInputLangChangeRequestFilter : IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x0050)
            {
                    return m.HWnd.ToInt64() > 0x7FFFFFFF;
            }
            return false;
        }
    }
