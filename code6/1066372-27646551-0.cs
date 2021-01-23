        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            // 0x210 is WM_PARENTNOTIFY
            // 513 is WM_LBUTTONCLICK
            if (m.Msg == 0x210 && m.WParam.ToInt32() == 513)
            {
                // get the clicked position
                var x = (int)(m.LParam.ToInt32() & 0xFFFF);
                var y = (int)(m.LParam.ToInt32() >> 16);
                // get the clicked control
                var childControl = this.GetChildAtPoint(new Point(x, y));
                // call onClick (which fires Click event)
                OnClick(EventArgs.Empty)
                // do something else...
            }
            base.WndProc(ref m);
        }
