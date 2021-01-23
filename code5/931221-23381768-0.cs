    public static void ToCSV(string fileWRITE, string fileREAD)
    {
        usint(var commas = new StreamWriter(fileWRITE))
        using(var file = new StreamReader("yourFile.txt"))
        {
            var line = file.ReadLine();
            while( line != null )
            { 
                string q = (y.Substring(0,15)+","+y.Substring(15,1)+","+y.Substring(16,6)+","+y.Substring(22,6)+ ",NULL,NULL,NULL,NULL");
                commas.WriteLine(q);
                line = file.ReadLine();
            }
        } 
    }
