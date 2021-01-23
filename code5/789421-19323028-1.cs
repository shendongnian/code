    public void SaveCVInfo2(string varOne,string varTwo, string  varThree...)
    {
       using (ConexionGeneralDataContext db = new ConexionGeneralDataContext())
       {
          Usuario_Web columna = new Usuario_Web();
          //Add new values to each fields
          columna.Nombre = varOne;
          columna.Apellido = varTwo;
          columna.Em_solicitado = varThree;
          //and the rest where the textboxes would have been
          
    
          //Insert the new Customer object
          db.Usuario_Web.InsertOnSubmit(columna);
          //Sumbit changes to the database
          db.SubmitChanges();
       }
    
    }
