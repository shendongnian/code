    public static string NextString(string textfind)
     {
     List<string> found = new List<string>();
     string linejd;
     string new_string = string.Empty;
    using (StreamReader efile = new StreamReader(FILENAME))
    {
        int counter = 0;
        while ((linejd = efile.ReadLine()) != null)
        {
            counter++;
            if (linejd.Contains(textfind))
            {
                found.Add(linejd);
                string nextstring = efile.ReadLine();
                return nextstring;
            }
        }
    }
   
    return (new_string); 
}
