	var query = 
		from etudiant in etudiants.AsEnumerable()
		join resultat in resultats.AsEnumerable()
		on etudiant.Field<string>("matricule") equals resultat.Field<string>("matricule")
		join cour in cours.AsEnumerable()
		on resultat.Field<string>("sigle") equals cour.Field<string>("sigle")
		select new { etudiant, cour };
	// Define structure of output table
	DataTable table = new DataTable();
	table.Columns.Add("Prenom", typeof(string));
	table.Columns.Add("Nom", typeof(string));
	table.Columns.Add("Sigle", typeof(string));
	table.Columns.Add("Cours", typeof(string));
	// Fill output table from query results
	foreach (var row in query)
	{
		DataRow newrow = table.NewRow();
		newrow["Prenom"] = row.etudiant.Field<string>("Prenom");
		newrow["Nom"] = row.etudiant.Field<string>("Nom");
		newrow["Sigle"] = row.cour.Field<string>("Sigle");
		newrow["Cours"] = row.cour.Field<string>("Cours");
		table.Rows.Add(newrow);
	}
