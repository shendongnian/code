    public DetailsForm(int ID, string LastName, string FirstName, string DateOfBirth)
    {
        InitializeComponent();
        textBox1.Text = ID.ToString();
        textBox2.Text = LastName;
        textBox3.Text = FirstName;
        dateTimePicker1.Value = DateTime.Parse(DateOfBirth);
    }
