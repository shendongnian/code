	var query = 
		from etudiant in etudiants.AsEnumerable()
		join resultat in resultats.AsEnumerable()
		on etudiant.Field<string>("matricule") equals resultat.Field<string>("matricule")
		join cour in cours.AsEnumerable()
		on resultat.Field<string>("sigle") equals cour.Field<string>("sigle")
		select new QueryResult
		{
			Prenom = etudiant.Field<string>("Prenom"),
			Nom = etudiant.Field<string>("Nom"),
			Sigle = resultat.Field<string>("Sigle"),
			Cours = resultat.Field<string>("Cours")
		};
	List<QueryResult> results = query.ToList();
	foreach (QueryResult row in results)
	{
		Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t",
			row.Prenom, row.Nom, row.Sigle, row.Cours
		);
	}
