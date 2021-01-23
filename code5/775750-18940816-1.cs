    string s= @"39 ??Issue:
    9 ??Pages:
    1307-1325 ??DOI:
    10.1109/TSE.2013.14 ??Published:";
    
    string[] splitValues = s.Split(new string[] { "??", "\r\n" }, StringSplitOptions.None);
    for (int i = 0; i < splitValues.Length; i += 2)
    {
        Console.WriteLine("value={0} index={1}", splitValues[i].Trim(), splitValues[i + 1].Trim());
    }
