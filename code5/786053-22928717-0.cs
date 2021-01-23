    List<Tuple<string, DateTime, string>> mylist = new List<Tuple<string, DateTime,string>>();
    mylist.Add(new Tuple<string, DateTime, string>(Datei_Info.Dateiname, Datei_Info.Datum, Datei_Info.Größe));
    for (int i = 0; i < mylist.Count; i++)
    {
         Console.WriteLine(mylist[i]);
    }
