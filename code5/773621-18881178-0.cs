    Dictionary<string, string> dict = new Dictionary<string, string>();
    dict.Add(KnownColor.ActiveBorder.ToString(), "BordeActivo");
    dict.Add(KnownColor.ActiveCaption.ToString(), "MensajeActivo");
    dict.Add(KnownColor.ActiveCaptionText.ToString(), "TextoMensajeActivo");
    //etc.    
    bool languageIsEnglish = true;
    foreach (string entry in dict.Keys)
    {
        string curVal = entry;
        if (!languageIsEnglish)
        {
            curVal = dict[entry];
        }
    
        comboBox1.Items.Add(curVal);
    }
