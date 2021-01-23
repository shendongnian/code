    var assembly = Assembly.GetExecutingAssembly();
    var resourceName = "MyProject.MyProjectFolder.TextFile1.txt";
    
    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
    using (StreamReader sr = new StreamReader(stream))
    {
        StringBuilder sb = new StringBuilder();
                sb.Append(sr.ReadToEnd());
    
                string[] resp = sb.ToString().Split('\t');
    
                Globals.round1 = Convert.ToDouble(resp[0]);
                Globals.round2 = Convert.ToDouble(resp[1]);
                Globals.round3 = Convert.ToDouble(resp[2]);
                Globals.round4 = Convert.ToDouble(resp[3]);
                Globals.round5 = Convert.ToDouble(resp[4]);
                Globals.round6 = Convert.ToDouble(resp[5]);
                Globals.round7 = Convert.ToDouble(resp[6]);
                Globals.round8 = Convert.ToDouble(resp[7]);
                Globals.jackpot = Convert.ToDouble(resp[8]);
    
    }
