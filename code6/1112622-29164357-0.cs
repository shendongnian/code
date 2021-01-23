    private List<Form> Windows { get; set; }
    
    public Form1()
    {
        InitializeComponent();
        this.Text = "Main Window";
        this.Windows = new List<Form>();
    
        var defaultSize = new Size(200, 100);
        for (var i = 0; i < 3; i++)
        {
            var form = new Form() { Size = defaultSize, Text = "Resize Me" };
            var suppressEvent = false;
    
            form.SizeChanged += (sender, e) =>
            {
                if (suppressEvent)
                    return;
    
                suppressEvent = true;
    
                defaultSize = (sender as Form).Size;
                foreach (var otherForm in this.Windows)
                {
                    if (otherForm != sender as Form)
                        otherForm.Size = defaultSize;
                }
                suppressEvent = false;
            };
    
    
            this.Windows.Add(form);
            form.Show();
        }
    }
