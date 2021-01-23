    public class ErrorDialog
    {
        //
        // When an exception happens, we show the message here
        //
        public static void Show(String text)
        {
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //
        // When an exception happens, we show the message here
        //
        public static void Show(Exception ex)
        {
            MessageBox.Show(ex.GetType().ToString() + ":" + ex.Message + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
