    while (line != null)
                {
                    string s = line;
                    string[] split = s.Split('\t');
                    nDate = Convert.ToDateTime(split[0]);
                    nStart = Convert.ToDateTime(split[1]);
                    nLength = Convert.ToInt32(split[2]);
                    nSubject = split[3];
                    nLocation = split[4];
                    listApps.Add(new Appointment(nSubject, nLocation, nStart, nLength, nDate));
                    line = fileReader.ReadLine();
                }
