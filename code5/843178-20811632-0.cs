Add the following line to form's constructor
    public Form1()
    {
       InitializeComponent();    
       dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);    
    }
dataGridView1_EditingControlShowing event
    void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
       dataGridView1.EditingControl.TextChanged += new EventHandler(EditingControl_TextChanged);
    }
EditingControl_TextChanged event
    void EditingControl_TextChanged(object sender, EventArgs e)
    {
       //Capturing the value typed into grid's cell
       string text = dataGridView1.EditingControl.Text;
    }
