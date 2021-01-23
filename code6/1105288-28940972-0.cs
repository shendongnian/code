    Try This
     dbr = cmd.ExecuteReader();
    while(dbr.read())
    {
      string value = dbr["Column Index"].toString();
    if(value == "Doctor" ){
      this.Visible = false;
      DoctorHome Dochome = new DoctorHome();
      Dochome.Show();
    }
    
    }
