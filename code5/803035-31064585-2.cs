    public multiplayerGame(int numberOfPlayers, string machineName)// int so the new form knows your passing an int, then the name of your variable same goes for the string variable
        {
            this.myPcName = machineName;// here you assign the private string created above for this form to equal the string variable being passed into this from form the previous form
            this.numPlayers = numberOfPlayers; // here you assign the private int created above for this form to equal the int variable being passed into this from form the previous form
            InitializeComponent();
        }
