        for (int i = 0; i < listView1.Columns.Count; i++)
        {
            if (var_depot == listView1.Columns[i].Text)
            {
                ajouterlistview1.SubItems.Add(reader["quantite"].ToString());
                break;
            }
            else
                ajouterlistview1.SubItems.Add("");
        }
