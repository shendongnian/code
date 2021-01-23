    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
          string txt="AB + CD";
    
          string re1="([a-z])";	// Any Single Word Character (Not Whitespace) 1
          string re2="([a-z])";	// Any Single Word Character (Not Whitespace) 2
          string re3="(\\s+)";	// White Space 1
          string re4="(\\+)";	// Any Single Character 1
          string re5="(\\s+)";	// White Space 2
          string re6="([a-z])";	// Any Single Word Character (Not Whitespace) 3
          string re7="([a-z])";	// Any Single Word Character (Not Whitespace) 4
    
          Regex r = new Regex(re1+re2+re3+re4+re5+re6+re7,RegexOptions.IgnoreCase|RegexOptions.Singleline);
          Match m = r.Match(txt);
          if (m.Success)
          {
                String w1=m.Groups[1].ToString();
                String w2=m.Groups[2].ToString();
                String ws1=m.Groups[3].ToString();
                String c1=m.Groups[4].ToString();
                String ws2=m.Groups[5].ToString();
                String w3=m.Groups[6].ToString();
                String w4=m.Groups[7].ToString();
                Console.Write("("+w1.ToString()+")"+"("+w2.ToString()+")"+"("+ws1.ToString()+")"+"("+c1.ToString()+")"+"("+ws2.ToString()+")"+"("+w3.ToString()+")"+"("+w4.ToString()+")"+"\n");
          }
          Console.ReadLine();
        }
      }
    }
