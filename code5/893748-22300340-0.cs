    internal class DecimalConverterFilter : IMessageFilter
    {
        private const uint WM_KEYDOWN = 0x100;
        public bool PreFilterMessage(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_KEYDOWN)
            {
                Keys toets = (Keys)Convert.ToInt32(m.WParam.ToInt32() & (int)Keys.KeyCode);
                if (toets == Keys.Decimal)
                {
                    SendKeys.Send(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    return true;
                }
            }
            return false;
        }
    }
