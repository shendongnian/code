    const string fileName = "100%ץצקרתﬤﬢ.jpg";
    var bytes = Encoding.Unicode.GetBytes(fileName);
    var doubleBytes = bytes.ToObservable().Buffer(2);
    
    var asciiFileName = new StringBuilder();
    doubleBytes.Subscribe(
        s =>
            asciiFileName.Append(s[1] == 0
                ? (s[0] == 37 ? "%25" : Convert.ToString((char) s[0]))
                : String.Format("%{0:X2}%{1:X2}", s[0], s[1]).PadLeft(2, '0')));
