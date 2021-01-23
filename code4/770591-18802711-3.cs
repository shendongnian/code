    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] arguments)//Windows passes an array of arguments which may be filesnames or folder names.
    {
        string avivsfolder = @"\Aviv";
        string folderpath = "";
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        if (arguments.Length > 0)//If an argument has been passed.
        {
            folderpath = arguments[0];
            try
            {
                if (Directory.Exists(folderpath))//Make sure the folder exists.
                {
                    Directory.CreateDirectory(folderpath + avivsfolder);
                    if (Directory.Exists(folderpath + avivsfolder))//To check if the folder was made successfully,if not an exception would stop program exceution,thus no need for 'else' clause.
                    {
                        MessageBox.Show("The specified folder was created successfully.", "Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    throw new DirectoryNotFoundException("The specified folder does not exist");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviv's Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else//No argument passed.
        {
            MessageBox.Show("You need to select a folder to continue.", "Aviv's Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
