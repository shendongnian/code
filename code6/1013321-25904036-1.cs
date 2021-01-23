    string[] fnames = { "Aleisha", "Sadye", "Ethyl");
    string[] lname = {"Smith","Johnson","Melody");
    Random r = new Random();
    int wfname = r.Next(fnames.Length);
    int wlname = r.Next(lnames.Length);
    var fullName = string.Format("{0} {1}", fnames[wfname], lname[wlname]);
    System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\names.txt", new [] { fullName });
