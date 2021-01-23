        private DialogResult STAShowDialog(FolderBrowserDialog dialog)
        {
            DialogState state = new DialogState();
            state.dialog = dialog;
            System.Threading.Thread t = new  
                   System.Threading.Thread(state.ThreadProcShowDialog);
            t.SetApartmentState(System.Threading.ApartmentState.STA);
            t.Start();
            t.Join();
            return state.result;
        }
        public class DialogState
        {
          public DialogResult result;
          public FolderBrowserDialog dialog;
          public void ThreadProcShowDialog()
          {
            result = dialog.ShowDialog();
          }
        }
