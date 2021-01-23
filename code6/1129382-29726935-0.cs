    public partial class LockScreen : Form
    {
    Timer checkTimer;
    string curPass = "";
    string pass = "salim";
    public LockScreen()
    {
        InitializeComponent();
        this.KeyPreview = true;
        this.WindowState = FormWindowState.Normal;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Bounds = Screen.PrimaryScreen.Bounds;
        this.ShowInTaskbar = false;
        double OpacityValue = 4.0 / 100;
        this.Opacity = OpacityValue;
        //this.KeyDown += OnKeyDown;
        this.KeyPress += LockScreen_KeyPress;
        checkTimer = new Timer();
        checkTimer.Interval = 1000;
        checkTimer.Tick += checkTimer_Tick;
    }
    void LockScreen_KeyPress(object sender, KeyPressEventArgs e)
    {
        checkTimer.Stop();
        curPass += e.KeyChar.ToString();
        if (curPass == pass)
        {
            checkTimer.Stop();
            this.Close();
        }
        else
            checkTimer.Start();
    }
    void checkTimer_Tick(object sender, EventArgs e)
    {
        curPass = "";  //resets every second
    }
    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.P && e.Modifiers == (Keys.Control | Keys.Shift | Keys.Alt))
        {
            this.Close();
        }
    }
    }
