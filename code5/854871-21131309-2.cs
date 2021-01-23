    static public void TurnOnApplicationSettings(Excel.Application xlApp)
    {
        xlApp.ScreenUpdating = true;
        xlApp.DisplayAlerts = true;
        xlApp.Calculation = xlCalculation;
        xlApp.UserControl = true;
        xlApp.EnableEvents = true;
    }
