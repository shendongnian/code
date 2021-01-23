    OleDb.OleDbConnection cn = new OleDb.OleDbConnection();
    cn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + Application.StartupPath + "\\data.mdb";
    cn.Open();
    
    byte[] arrImage = null;
    string strImage = null;
    IO.MemoryStream myMs = new IO.MemoryStream();
    //
    if ((this.picPhoto.Image != null)) {
    	this.picPhoto.Image.Save(myMs, this.picPhoto.Image.RawFormat);
    	arrImage = myMs.GetBuffer;
    	strImage = "?";
    } else {
    	arrImage = null;
    	strImage = "NULL";
    }
    
    OleDb.OleDbCommand myCmd = new OleDb.OleDbCommand();
    myCmd.Connection = cn;
    myCmd.CommandText = "INSERT INTO tblstudent(stdid, [name], photo) " + " VALUES(" + this.txtID.Text + ",'" + this.txtName.Text + "'," + strImage + ")";
    if (strImage == "?") {
    	myCmd.Parameters.Add(strImage, OleDb.OleDbType.Binary).Value = arrImage;
    }
    
    Interaction.MsgBox("Data save successfully!");
    myCmd.ExecuteNonQuery();
    cn.Close();
