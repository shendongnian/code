    public partial class Form1 : Form
    {
        //
        // Your class properites/variables
        //
        AlertDialogHandler dialogHandler;
        [DllImport("User32.dll")]
        public static extern Int32 FindWindow(String lpClassName, String lpWindowName);
        //
        // Some methods/functions declarations
        //
        public void SomeInitMethod()
        {
              dialogHandler = new AlertDialogHandler()
              browse.AddDialogHandler(dialogHandler);
        }
        public void SampleMethod()
        {
           IntPtr hwndTmp = (IntPtr)FindWindow("#32770", "Dialog Title");
           WatiN.Core.Native.Windows.Window popUpDialog = new Window(hwndTmp);
           dialogHandler.HandleDialog(popUpDialog);
           //
           // The line above will find the OK button for you and click on it, 
           // from here you continue with the rest of your code.
        }
    }
