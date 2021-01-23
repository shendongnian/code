    private void InitializeComponent()
    {
        this.button1 = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // button1
        // 
        this.button1.Name = "button1";
    
        //This is the line that has the compile error.
        this.button1.Click += new System.EventHandler(this.button1_Click);
    }
