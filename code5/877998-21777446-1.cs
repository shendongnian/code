    class CLogParser
    {
        LogStruct m_logStruct;
        public CLogParser()
        {
             m_logStruct = new LogStruct();
        }
        public void ThreadProc(object param)
        {
            string logName = (string)param;
            StreamReader file;
            try
            {
                file = new StreamReader(logName);
            }
            catch
            {
                return;
            }
            string line;
            while ((line = file.ReadLine()) != null)//may be,something wrong here
            {
                var space_pos = line.IndexOf(' ');
                if (space_pos > 0)
                {
                    string[] parameters = line.Split(new Char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
                    string domainName = parameters[0];
                    bool isMainPage = (parameters[4] == "\"-\"") ? true : false;
                    string relativePageAddress = (isMainPage) ? "/" : parameters[5];
                    Regex reg = new Regex(" \\d+");
                    MatchCollection matches = reg.Matches(line);
                    string errorCode = matches[1].Value;
                    ulong pageSize = (matches.Count > 2) ? Convert.ToUInt64(matches[2].Value) : 0;
                    string fullAdress = domainName + relativePageAddress;
                    string fullErrCode = domainName + errorCode;
                    if (m_logStruct.domainName.ContainsKey(domainName))
                    {
                        m_logStruct.domainName[domainName]++;
                        m_logStruct.domainData[domainName] += pageSize;
                        if (m_logStruct.URL.ContainsKey(fullAdress))
                        {
                            m_logStruct.URL[fullAdress]++;
                        }
                        else
                        {
                            m_logStruct.URL.AddOrUpdate(fullAdress, 1, Update);
                        }
                        if (m_logStruct.errorCodes.ContainsKey(fullErrCode))
                        {
                            m_logStruct.errorCodes[fullErrCode]++;
                        }
                        else
                        {
                            m_logStruct.errorCodes.AddOrUpdate(fullErrCode, 1, Update);
                        }
                    }
                    else
                    {
                      
                        m_logStruct.domainName.AddOrUpdate(domainName, 1, Update);
                        m_logStruct.domainData.AddOrUpdate(domainName, pageSize, Update);
                        m_logStruct.URL.AddOrUpdate(fullAdress, 1, Update);
                        m_logStruct.errorCodes.AddOrUpdate(fullErrCode, 1, Update);
                    }
                }
            }
        }
        public ulong Update(String key, ulong existingVal)
        {
            // Implement if you expect values to exist 
        }
    }
