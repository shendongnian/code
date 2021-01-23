      SqlCeCommand commandArbeitstage = new SqlCeCommand("SELECT DATEPART (month, Datum) AS   Monat, COUNT(IDStundensatz) AS AnzahlTage FROM tblstunden WHERE IDPersonal = @IDPersonal GROUP BY DATEPART(month,datum)", verbindung);
                commandArbeitstage.Parameters.Add("IDPersonal", SqlDbType.Int);
                commandArbeitstage.Parameters["@IDPersonal"].Value = IDPersonal;
                
                
                SqlCeDataReader readerArbeitstage = commandArbeitstage.ExecuteReader();
                 Int32[] Arbeitstage = new Int32[13];
                while (readerArbeitstage.Read())
                 {
                    int mnth = Convert.ToInt32(readerArbeitstage["Monat"].ToString());
                    Arbeitstage[mnth] = Convert.ToInt32(readerArbeitstage["AnzahlTage"].ToString());
                 }
               
                ATageJan.Text = Arbeitstage[1].ToString();
                ATageFeb.Text = Arbeitstage[2].ToString();
                ATageMrz.Text = Arbeitstage[3].ToString();
                ATageApr.Text = Arbeitstage[4].ToString();
                ATageMai.Text = Arbeitstage[5].ToString();
                ATageJun.Text = Arbeitstage[6].ToString();
                ATageJul.Text = Arbeitstage[7].ToString();
                ATageAug.Text = Arbeitstage[8].ToString();
                ATageSep.Text = Arbeitstage[9].ToString();
                ATageOkt.Text = Arbeitstage[10].ToString();
                ATageNov.Text = Arbeitstage[11].ToString();
                ATageDez.Text = Arbeitstage[12].ToString();
