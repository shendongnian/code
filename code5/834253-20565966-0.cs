        Examen eersteExamen = new Examen(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), 2, 2, true, "Bouwmeesterstraat", 1);
        Examen tweedeExamen = new Examen(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), 2, 3, true, "Schilderstraat", 2);
        Examen derdeExamen = new Examen(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), 2, 3, true, "Meistraat", 3);
        //Creatie test data
        List<Examen> origineleLijst = new List<Examen>();
        origineleLijst.Add(eersteExamen);
        origineleLijst.Add(tweedeExamen);
        origineleLijst.Add(derdeExamen);
        List<string> stedenLijst = new List<string>();
        stedenLijst.Add("Meistraat");
        List<Examen> verwachteLijst = new List<Examen>();
        verwachteLijst.Add(derdeExamen);
        //methode oproepen en assert
        List<Examen> resultLijst = FilterModel.filterExamensCities(origineleLijst, stedenLijst);
        //use one of these depending on whether Examen implements Equals and GetHashcode properly.       
        CollectionAssert.AreEqual(verwachteLijst, resultLijst, "Fout");
        CollectionAssert.AreEquivalent(verwachteLijst, resultLijst, "Fout");
    }
