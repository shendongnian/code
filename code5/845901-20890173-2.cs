     da2.Fill(dss, "cliente"); 
            DataRow nova = dss.Tables["cliente"].Rows[0];
            nova.BeginEdit();
            nova["nome"] = TxtNome.Text;
            nova.EndEdit();
            da2.Update(dss.Tables["cliente"]);    
          nova.AcceptChanges();
          nova.SetModified();// Must call this lines
