    [STAThread]
    static void Main()
    {
        // create object of startup class and call initialize method
        StartUp newStartUp = new StartUp();
        newStartup.Initialize();
        Application.Run(new Form1());
    }
    StartUp.cs
    ----------
    public class StartUp
    {
        public void Initialize()
        {
            MyAppSettings.ShowMoves = true;    
        }
    }
    MyAppSettings.cs
    ----------------
    public static MyAppSettings
    {
        public static bool ShowMoves {get; set;}
    }
    Form1.cs
    --------
    private void Form1_Load(object sender, EventArgs e)
    {
        CreateGroupBox();
        //Set Initial Settings 
        movesToolStripMenuItem.Checked = MyAppSetting.ShowMoves;
    }
    
