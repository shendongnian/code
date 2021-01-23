	private static XlCalculation xlCalculation = XlCalculation.xlCalculationAutomatic;
	static public void TurnOffApplicationSettings(Excel.Application xlApp)
	{
		xlApp.ScreenUpdating = false;
		xlApp.DisplayAlerts = false;
		xlCalculation = xlApp.Calculation; //Record the current Calculation Mode
		xlApp.Calculation = XlCalculation.xlCalculationManual;
		xlApp.UserControl = false;
		xlApp.EnableEvents = false;
	}
