    Console.WriteLine("{{Hello World!:)".Trim('{',':',')'));  //output: Hello World
    Console.WriteLine("{{Hello%World!:)".Trim('{', '%', ':',')'));  //output: Hello%World
    Console.WriteLine("{{Hello World!:)".Replace("{{", string.Empty)
                                        .Replace(":)",string.Empty));  //output: Hello World
    Console.WriteLine("{{Hello%World!:)".Replace("{{", string.Empty)
                                        .Replace("%", string.Empty)
                                        .Replace(":)",string.Empty));  //output: Hello World
