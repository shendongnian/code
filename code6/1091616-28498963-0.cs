    var specialCharacters = "çõéó";
    var goodEncoding = Encoding.UTF8;
    var badEncoding = Encoding.GetEncoding(28591);
    var badStrings = specialCharacters.Select(c => badEncoding.GetString(goodEncoding.GetBytes(c.ToString())));
    		
    var sourceText = "ServiÃ§os de ComunicaÃ§Ãµes e MultimÃ©dia";
    if(badStrings.Any(s => sourceText.Contains(s)))
    {
    	sourceText = goodEncoding.GetString(badEncoding.GetBytes(sourceText));
    }
