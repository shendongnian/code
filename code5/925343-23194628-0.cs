    private void cmdCommand_Click(object sender, EventArgs e)
    {
        dbConnect = new DBConnect();
        List<string>[] list;
        //get list from database
        list = dbConnect.Connect(); //ERROR:Object reference not set to an instance of an object.
        for (int i = 0; i < list[0].Count; i++)
        {
            string ipAdd = list[0][i]; 
            CmdConnect(ipAdd, txtPort.Text); //call function connect
        }
    }
