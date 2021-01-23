    public void SetNewData (string playerName, DateTime bornDate)
    {
        string newLine = playerName + " " + bornDate.ToString () + " 0 0 0 0";
        using(StreamWriter myWriter = new StreamWriter(this.myFile))
			myWriter.WriteLine(newLine);
    }
<!---->
	public void SetNewData (string playerName, DateTime bornDate)
    {
        string newLine = playerName + " " + bornDate.ToString () + " 0 0 0 0";
        StreamWriter myWriter = new StreamWriter(this.myFile);
        myWriter.WriteLine(newLine);
		myWriter.Flush();
        myWriter.Close();
    }
	
