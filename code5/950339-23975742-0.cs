    for (int i = 0; i <data.Rows.Count; i++)
    {
        // Create a new Groupe
        var item = new Groupe();
        // Set the properties
        item.Codegroupe = int.Parse(data.Rows[i][0].ToString());
        item.Nom = data.Rows[i][1].ToString();
        item.Année = int.Parse(data.Rows[i][2].ToString());
        
        // Add it to the list.
        listgrp.Add(item);
    }
