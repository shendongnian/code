    static void Main()
{
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    Form1 Mainwindow = new Form1();
    
    Mainwindow.button1.Text = "TextToChangeTo"; 
    Application.Run(Mainwindow);
