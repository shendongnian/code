    var input = @"L**\x26#39**;utilisateur ne dispose pas d**\x26#39**;un bureau configur**�**";
    var result = Regex.Replace(input, @"\*\*([^*]*)\*\*", "$1");  // Take out the extra stars 
    // Unescape \x values
    result = Regex.Replace(result,
                           @"\\x([a-fA-F0-9]{2})",
                           match => char.ConvertFromUtf32(Int32.Parse(match.Groups[1].Value,
                                                                      System.Globalization.NumberStyles.HexNumber)));
    // Decode html entities
    result = System.Net.WebUtility.HtmlDecode(result);
