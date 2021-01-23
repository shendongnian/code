	SqlCeCommand commandArbeitstage= new SqlCeCommand("select datepart(month, Datum) as Month, count(IDStundensatz) as Gesamt from tblstunden Where IDPersonal = @IDPersonal Group by datepart(month, Datum) Order By datepart(month, Datum)", verbindung);
	commandArbeitstage.Parameters.Add("IDPersonal", SqlDbType.Int);
	commandArbeitstage.Parameters["@IDPersonal"].Value = IDPersonal;
	SqlCeDataReader readerArbeitstage = commandArbeitstage.ExecuteReader();
	Dictionary<Int32, Int32> Arbeitstage = new Dictionary<Int32, Int32>;
	while (readerArbeitstage.Read())
	{
		Arbeitstage.Add(readerArbeitstage.GetInt32(0), readerArbeitstage.GetInt32(1));
	}
	if (Arbeitstage.ContainsKey(1))	
		textBox53.Text = Arbeitstage[1].ToString();
	else
		textBox53.Text = "0";
	// ... and so on up to 12
