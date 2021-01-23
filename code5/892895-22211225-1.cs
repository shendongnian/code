	SqlCeCommand commandArbeitstage= new SqlCeCommand("select datepart(month, Datum) as Month, count(IDStundensatz) as Gesamt from tblstunden Where IDPersonal = @IDPersonal Group by datepart(month, Datum) Order By datepart(month, Datum)", verbindung);
	commandArbeitstage.Parameters.Add("IDPersonal", SqlDbType.Int);
	commandArbeitstage.Parameters["@IDPersonal"].Value = IDPersonal;
	SqlCeDataReader readerArbeitstage = commandArbeitstage.ExecuteReader();
	Int32[] Arbeitstage = new Int32[12];
	while (readerArbeitstage.Read())
	{
		Arbeitstage[readerArbeitstage.GetInt32(0) - 1]  = readerArbeitstage.GetInt32(1));
	}
	textBox53.Text = Arbeitstage[0].ToString();  // January
	// ... and so on up to 11
