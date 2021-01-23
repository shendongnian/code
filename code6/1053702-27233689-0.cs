    private string usrID;
    public string UserID //Correct style!
    {
       get { return usrID; }
       set
       {
          usrID = value;
          RCtextBox.Text = usrID;
       }
    }
