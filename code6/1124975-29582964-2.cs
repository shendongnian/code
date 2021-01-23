    `foreach (string word in _AppList)
    {
        string s = word;
        string[] split = s.Split('\t');
        nDate = Convert.ToDateTime(split[0]);
        nStart = Convert.ToDateTime(split[1]);
        nLength = Convert.ToInt32(split[2]);
        nSubject = split[3];
        nLocation = split[4];
        replicaList.Add(new Appointment(nSubject, nLocation, nStart, nLength, nDate));
    }`
