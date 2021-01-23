    using System.Globalization;
    string a = "abc";
    string b = "AC";
    Console.WriteLine("Length a = {0}", new StringInfo(a).LengthInTextElements);
    Console.WriteLine("Length b = {0}", new StringInfo(b).LengthInTextElements);
