      public override int ExecuteNonQuery(string query)
        {
            
            int register=0;
            //SQLiteTransaction trx=null;
            SQLiteCommand com;
            try
            {
                if (con.State == ConnectionState.Closed) this.Open();
                    //trx = con.BeginTransaction();//para hacer transaciones para que la base de datos este estable
                    com = new SQLiteCommand(query, con);
                    //com.Transaction = trx;
                    register = com.ExecuteNonQuery();//recien hacemos la coneccion en esta linea
                   // trx.Commit();
               
                return register;
            }
            catch (SQLiteException ex)
            {
               // trx.Rollback();//se tiene q deshaser toda la trransaccion hecha
                throw ex;
            }
            finally
            {
                this.Close();
            }
        }
