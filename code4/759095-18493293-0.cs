    public int CountDecPoint(decimal d){
       string[] s = d.ToString().Split(Application.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]);
       return s.Length == 1 ? 0 : s[1].Length;
    }
    
