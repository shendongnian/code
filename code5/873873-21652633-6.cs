    private string currentConnection = "<default connection>";
    public Form1() {
       InitializeComponent();
       var firstConnection = new ComboItemExample { DisplayString = "Local Database", ConnectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;" };
       myComboBox.Items.Add(firstConnection);
       var secondConnection = new ComboItemExample { DisplayString = "Other Database", ConnectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;" };
       myComboBox.Items.Add(secondConnection);
    }
