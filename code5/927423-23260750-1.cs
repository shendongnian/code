    public class MainForm()
    {
        // Declare the button as a field in order to have access to it
        // in any property/method/constructor within the class
        private myButtonObject start;
    
        ...
    }
    
    public MainForm() 
    {
        InitializeComponent();
    
        start = new myButtonObject();
        EventHandler myHandler = new EventHandler(start_Click);
        start.Click += myHandler;
        start.Location = new System.Drawing.Point(200, 500);
        start.Size = new System.Drawing.Size(101, 101);
        this.Controls.Add(start);
        ...
    } 
     
    private void setInvisible() 
    {
        ...
        // You can access the button within setInvisible() method
        start.Visible = false;
    }
