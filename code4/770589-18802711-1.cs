    static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main(string[] arguments)//Windows passes an array of arguments which may be filesnames or folder names.
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                if (arguments.Length > 0)//If an argument has been passed.
                {
                    string foldername=arguments[0];//This is the foldername.
                    //Do what you want,with this folder name.
                }
                else//No argument passed.
                {
                    MessageBox.Show("You need to select a folder to continue.", "Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
