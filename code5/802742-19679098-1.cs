    DateTime dt = dtiFrom.Value.Date;
    string format = "dd-MM-yyyy";
    DateTime dt1 = new DateTime();
    if (DateTime.TryParseExact(dt , format, null , DateTimeStyles.None, out dt1))
    {
      // you can use dt1 here
    }
    else
    {
      MessageBox.Show("Error Massage");
    }
