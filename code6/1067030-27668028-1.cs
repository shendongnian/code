        static bool busy = false;
        private void tmr_sysdt_Tick(object sender, EventArgs e)
        {
            if (busy)
            {
                return;
            }
            busy = true;
            try
            {
                lbl_time.Text = System.DateTime.Now.ToLongTimeString();
                lbl_date.Text = System.DateTime.Now.ToLongDateString();
                if (GetLastInputTime() > Program.timeout)
                {
                    frm_lockscreen login = new frm_lockscreen();
                    tmr_sysdt.Enabled = false;
                    if (login.ShowDialog(this) == DialogResult.OK) tmr_sysdt.Enabled = true;
                }
            }
            finally
            {
                busy = false;
            }
        }
