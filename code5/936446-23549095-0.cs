     private void StergeElement(string nume)
        {
            conexiune.Open();
            Comanda comanda = new Comanda("delete from staff where SID=@ID", conexiune);
            comanda.Parameters.Add(new SqlParameter("@ID", nume));
            comanda.ExecuteNonQuery();
             comanda = new Comanda("delete from echipa where EID=@ID", conexiune);
            comanda.Parameters.Add(new SqlParameter("@ID", nume));
           
            comanda.ExecuteNonQuery();
            
            conexiune.Close();
            MessageBox.Show("Succes");
        }
