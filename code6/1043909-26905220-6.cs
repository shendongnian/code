    string newText = "";
    for (int s = 0; s < texts.Length; s++)
    {
        newText = "";
        for (int i = 0; i < 3; i++)
        {
            if (texts[s][i] == 'n') newText += numBase[i];
            else  newText +=  (Convert.ToByte(numBase[i].ToString()) + 
                                Convert.ToByte(reference[0].ToString()) ).ToString("0");
        }
        texts[s] = newText;
    }
