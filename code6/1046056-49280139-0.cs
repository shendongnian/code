    using System.Text.RegularExpressions;
    using System.Linq;
    string pattern = @"(\d+)";
    string barcode = "ABC123456DEF";
    string[] result = Regex.Split(barcode, pattern).Where(s => !string.IsNullOrEmpty(s)).ToArray();
    
