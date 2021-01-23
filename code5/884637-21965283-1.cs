    using System.IO;
    
    using System;
    
    using System.Collections.Generic;
    
    class Program
    
    {
        static void Main()
        {
            
        List<string> lstrSample = new List<string>();
        
        lstrSample.Add("1 - 12/2015 - 12/2016");lstrSample.Add("2 - 12/2015 - 12/2016");
        List<string> lstrResult = new List<string>();
        foreach(string curStr in lstrSample)
        {
          lstrResult.Add(curStr.Replace(" ","").Split('-')[0]);
        }
        foreach(string s in lstrResult)
        {
            Console.WriteLine(s);
        }
    }
}
