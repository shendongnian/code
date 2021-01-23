    `foreach (Control ctrl in bodyPanel.Controls)
    {
    if (ctrl.GetType().Name == "TimerUserControl")
    {
    TimerUserControl obj = ctrl as TimerUserControl;
    obj.ResetControl();
                }
            }`
