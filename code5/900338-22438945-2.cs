    try
    { 
        StringBuilder msg = new StringBuilder();
    	for (int i = 0; i < TurAltKatSecilenler.Length; i++)
    	{
    		msg.Append(TurAltKatSecilenler[i].ToString()+Environment.NewLine);    		
    		cmdTurAlt.Parameters.Add("AltKategoriID",TurAltKatSecilenler[i]);
    		cmdTurAlt.Parameters.Add("AnaKategoriID",dlTurAnaKategori.SelectedValue);
    		cmdTurAlt.Transaction = sqlTrans;    
    		cmdTurAlt.ExecuteNonQuery(); 
    		sqlTrans.Commit();
            cmdTurAlt.Parameters.Clear();
    	}
        Response.Write(msg);
    }
