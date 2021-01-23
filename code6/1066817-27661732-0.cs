        protected override bool ProcessTabKey(bool forward)
        {
            Control ctl = this.ActiveControl;
            if (ctl != null && ctl is TextBox)
            {
                if (((TextBox)ctl).Text.Length == 0)
                    return false; // prevent TAB
            }
            return base.ProcessTabKey(forward); // process TAB key as normal
        }
