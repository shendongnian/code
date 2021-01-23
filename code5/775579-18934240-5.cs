        using System;
        using System.Text.RegularExpressions;
        namespace RegexTest
        {
            class MainClass
            {
                public static void Main(string[] args)
                {
                    string[] cases =
                    {
                        "Šios sutarties sąlygos taikomos „Microsoft. Hotmail“, „Microsoft. SkyDrive“, „Microsoft“ abonementui.",
                        "Šios sutarties sąlygos taikomos „Microsoft“. Hotmail, „Microsoft. SkyDrive“, „Microsoft“ abonementui! Ok? more",
                        "1. Hello world. And MORE.",
                        "V. Hello world. And MORE.",
                        "1. V. Hello world. And MORE.",
                        "I am in room 102. And you?",
                    };
                    var re = new Regex("(.*?„.*?“)*?[^„]*?(((?<!\\b(\\d|[A-Z]))\\.)|[!?])");
                    foreach (var case_ in cases) {
                        foreach (Match m in re.Matches(case_))
                            Console.WriteLine(m);
                        
                        Console.WriteLine("------------I am a splitter :) ------------");
                    }
                }
            }
        }
