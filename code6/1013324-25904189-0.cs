    string[] fnames = { "Aleisha", "Sadye", "Ethyl");
    string[] lname = {"Smith","Johnson","Melody");
    Random r = new Random();
    string wfname = r.Next(fnames[0],fnames[2]);
    string wlname = r.Next(lnames[0],lnames[2]);
    
    var name = string.Format("{0} {1}", wfname, wlname);
    System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\names.txt", new [] { name });
