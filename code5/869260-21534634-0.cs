    public static class ApplicationCloseHelper
    {
        public static void CloseApplication()
        {
            if (UserIsSure())
            {
                Application.Exit();
            }
        }
    
        private static bool UserIsSure()
        {    
            string exitMessageText = "Are you sure you want to exit the application?";
            string exitCaption = "Cancel";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            DialogResult res = MessageBox.Show(exitMessageText, exitCaption, button, MessageBoxIcon.Exclamation);
            return res == DialogResult.Yes;
        }
    }
