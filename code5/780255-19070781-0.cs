    DateTimePicker dateTimePicker1 = new DateTimePicker();
    public Form1()
    {
        InitializeComponent();
        dateTimePicker1.Format = DateTimePickerFormat.Custom;
        dateTimePicker1.CustomFormat = "yyyy-mm-dd";
        //You can play with this to change location
        dateTimePicker1.Location = new Point(20, 20);
        this.Controls.Add(dateTimePicker1);
    }
