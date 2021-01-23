    SqlCommand cmd = new SqlCommand(@"update filme set Nume = @Nume, Gen = @Gen, 
                                      Descriere = @Descriere, Actori = @Actori, 
                                      An = @An, Rating = @Rating, Pret = @Pret 
                                      where ID = @ID");
    cmd.CommandType = CommandType.Text;
    cmd.Connection = connection;
    cmd.Parameters.Add(new SqlParameter 
                       { ParameterName = @Nume,
                         SqlDbType = SqlDbType.Int,
                         Value = Convert.ToInt32(someTextBox.Text)
                       };
    ...and so on for the other parameters...
