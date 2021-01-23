    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;
    
    namespace RegexSplit
    {
        class Program
        {
            static void Main(string[] args)
            {
                string str = "array[0]=[1,2,3,4,5,6];array[1]=[1,2,4,6,2,8];array[2]=[...]";
    
                Regex r = new Regex(@"(?<=\]=)(\[.+?\])");
    
                string[] results = r.Matches(str).Cast<Match>().Select(p => p.Groups[1].Value).ToArray();
            }
        }
    }
