    struct KlasStruct
    {
     public string Naam;
     public int AantalUur;
    }
    
    List<KlasStruct> Klas =new List<KlasStruct>();
    private void btnMaakLessenrooster_Click(object sender, EventArgs e)
    {
      //add a try catch
        string queryVakkenNaam = "SELECT Naam FROM Vakken";
        OleDbDataAdapter dAdapterVakkenNaam = new OleDbDataAdapter(queryVakkenNaam, 
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Project Officieel\Project_MagnusCurriculum\Project_MagnusCurriculum\Project.accdb");
    
        DataTable sourceVakkenNaam = new DataTable();
        dAdapterVakkenNaam.Fill(sourceVakkenNaam);
    
        for (int i = 0; i <= sourceVakkenNaam.Rows.Count - 1; i++)
        {
             KlasStruct kStruct = new KlasStruct(); ;
             kStruct.Naam = Convert.ToString(sourceVakkenNaam.Rows[i]["Naam"]);
             Klas.Add(kStruct);
        }
    
       
    }
