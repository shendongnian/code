        private void ActiveGanttCSNCtl1_CustomTierDraw(object sender, AGCSN.CustomTierDrawEventArgs e)
        {
            if (e.Interval == E_INTERVAL.IL_HOUR & e.Factor == 12)
            {
                e.Text = e.StartDate.ToString("tt").ToUpper();
            }
            if (e.Interval == E_INTERVAL.IL_MONTH & e.Factor == 1)
            {
                e.Text = e.StartDate.ToString("MMMM yyyy");
            }
            if (e.Interval == E_INTERVAL.IL_DAY & e.Factor == 1)
            {
                e.Text = e.StartDate.ToString("ddd d");
            }
        }
