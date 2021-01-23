    Seats[] seatArray = new Seats[14]; 
    seatArray[0] = new Seat();   // or something like this
    public Form1()
    {
        InitializeComponent();
        listBox2.Items.Add("ROW#   A   B   C   D   E   F");
        listBox2.Items.Add("  1    " + s.PrintInfo);
        listBox2.Items.Add( seatArray[0].PrintInfo); //HEREEE
