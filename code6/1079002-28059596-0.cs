    public class GlobalObjects
    {
        private static OpenFileDialog ofd;
        public static OpenFileDialog OpenFileDlg
        {
            get
            {
                if (ofd == null)
                    ofd = new OpenFileDialog();
                return ofd;
            }
        }
    }
