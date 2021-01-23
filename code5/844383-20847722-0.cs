    //protected override void WndProc(ref Message m)
    //{
    //  if (_isNull)
    //  {
    //    if (m.Msg == 0x4e)                         // WM_NOTIFY
    //    {
    //      NMHDR nm = (NMHDR)m.GetLParam(typeof(NMHDR));
    //      if (nm.Code == -746 || nm.Code == -722)  // DTN_CLOSEUP || DTN_?
    //        SetToDateTimeValue();
    //    }
    //  }
    //  base.WndProc(ref m);
    //}
    protected override void OnCloseUp(EventArgs eventargs) {
      if (_isNull) {
        SetToDateTimeValue();
      }
      base.OnCloseUp(eventargs);
    }
