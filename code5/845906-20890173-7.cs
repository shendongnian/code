    da2.Fill(dss); 
    DataRow nova = dss.Tables[0][0];
    nova.BeginEdit();
    nova["nome"] = TxtNome.Text;
    nova.EndEdit();
    da2.Update(dss);
