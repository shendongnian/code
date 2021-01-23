    int getDecimals (decimal d)
    {
        try
        {
            int s = Convert.ToInt32(string.Format("{0}", d.ToString().Split('.')[1]));
            return s;
        }
        catch { //whatever u want// }
    }
    
    // ==> //
    
    decimal d = 44.22m;
    
    string s = getDecimals(d).ToString();
