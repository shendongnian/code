    var original = "1923787:0";
    var bytesFromOriginal = System.Text.Encoding.Unicode.GetBytes(original);
    var base64string = Convert.ToBase64String(bytesFromOriginal);
    base64string = "MQA5ADIAMwA3ADgANwA6ADAA";
    var bytesFromEncodedString = Convert.FromBase64String(base64string);
    var decodedString = System.Text.Encoding.Unicode.GetString(bytesFromEncodedString);
