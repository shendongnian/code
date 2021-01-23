    using(OleDbCommand Queryyy = new OleDbCommand(bn, conexao))
    {
       try
       {
           var result = Queryyy.ExecuteScalar();
           if (result != null)
           {
              MessageBox.Show("Hi");
           }
        }
        catch (OleDbException ex)
        {
           MessageBox.Show("" + ex);
        }
       }
    }
