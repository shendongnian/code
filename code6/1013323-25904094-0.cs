    string[] fnames = { "Aleisha", "Sadye", "Ethyl" };
    string[] lnames = { "Smith", "Johnson", "Melody" };
    Random r = new Random();
    int wfname = r.Next(fnames.Length);
    int wlname = r.Next(lnames.Length);
    System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\names.txt", new[] {
    fnames[wfname ],
    lnames[wlname  ]});
