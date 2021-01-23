    List<CheckBox> cbList=new List<CheckBox>();
    public Form1()
    {
            InitializeComponent();
            btnOne.Click += btnOne_Click;
            cbList.Add(chckOne);
            cbList.Add(chckTwo);
            //All the checkbox should be added into cbList.
    }
    void btnOne_Click(object sender, EventArgs e)
    { 
        lstOne.Items.Clear();  
        var checked_checkbox = cbList.Where(cb=>cb.Checked==true).ToList();
        if(checked_checkbox.Count>0)
        {
            checked_checkbox.ForEach(x=>lstOne.Items.Add(x.Text));// Maybe you want put text of checkbox into listbox.
        }
    }
