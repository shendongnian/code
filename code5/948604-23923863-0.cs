    private void ActiveGanttCSNCtl1_ToolTipOnMouseHover(object sender, AGCSN.ToolTipEventArgs e)
            {
                switch (e.EventTarget)
                {
                    case E_EVENTTARGET.EVT_TASK:
                        ActiveGanttCSNCtl1.ToolTip.Visible = true;
                        return;
                }
                ActiveGanttCSNCtl1.ToolTip.Visible = false;
            }
