    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
            case WM_COPYDATA:
              
                COPYDATASTRUCT CD = (COPYDATASTRUCT)m.GetLParam(typeof(COPYDATASTRUCT));
                byte[] B = new byte[CD.cbData];
                IntPtr lpData = CD.lpData;
                Marshal.Copy(lpData, B, 0, CD.cbData);
                string strData = Encoding.Default.GetString(B);
                listBox1.Items.Add(strData);
                                 
                break;
            default:
                base.WndProc(ref m);
                break;
        }
    }
