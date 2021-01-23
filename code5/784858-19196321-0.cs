    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;
    using System.Globalization;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] crdlist = {
                                        "X:-6625.5 Y:-6585.5",
                                        "X:-6601.25 Y:-6703.75",
                                        "X:-6361 Y:-6516.5",
                                        "X:-6384 Y:-6672",
                                        "X:-6400.25 Y:-6847.75",
                                        "X:-6608.75 Y:-6793",
                                        "X:-6739.75 Y:-6872",
                                        "X:-6429.25 Y:-6940",
                                        "X:-7015.5 Y:-6835.5",
                                        "X:-7117 Y:-6903",
                                        "X:-6885.5 Y:-6662.5",
                                        "X:-6861.5 Y:-6597",
                                        "X:-7006.5 Y:-6728",
                                        "X:-7009 Y:-6608.75",
                                        "X:-6924 Y:-6798",
                                        "X:-6970.25 Y:-6898.25",
                                        "X:-6495.25 Y:-6775",
                                        "X:-7112.5 Y:-6614.5",
                                        "X:-7115.25 Y:-6717.25",
                                        "X:-7113.25 Y:-6835.5",
                                        "X:-6493 Y:-6620.25"
                                   };
    
                Regex re = new Regex(@"^\ *X\:([\-\.0-9]*)\ *Y\:([\-\.0-9]*)\ *$", RegexOptions.Compiled);
                var us_EN = new CultureInfo("en-US");
    
                foreach(var line in crdlist)
                {
                    Match m = re.Match(line);
                    if (m.Success)
                    {
                        String X = m.Groups[1].Value;
                        String Y = m.Groups[2].Value;
    
                        float fX = float.Parse(X, us_EN);
                        float fY = float.Parse(Y, us_EN);
    
                        Console.WriteLine("X={0}, Y={1}", fX, fY);
                    }
                }
    
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
    
            }
        }
    }
