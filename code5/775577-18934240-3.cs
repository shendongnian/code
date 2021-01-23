        using System;
        using System.Text.RegularExpressions;
        namespace RegexTest
        {
            class MainClass
            {
                public static void Main(string[] args)
                {
                    var re = new Regex("(.*?„.*?“)*?[^„]*?[.!?]");
                    string s1 = "Šios sutarties sąlygos taikomos „Microsoft. Hotmail“, „Microsoft. SkyDrive“, „Microsoft“ abonementui.";
                    foreach (Match m in re.Matches(s1))
                        Console.WriteLine(m);
                    Console.WriteLine("------------------------");
                    string s2 = "Šios sutarties sąlygos taikomos „Microsoft“. Hotmail, „Microsoft. SkyDrive“, „Microsoft“ abonementui! Ok? more";
                    foreach (Match m in re.Matches(s2))
                        Console.WriteLine(m);
                }
            }
        }
