    class LogStruct
    {
        public ConcurrentDictionary<string, ulong> domainName;
        public ConcurrentDictionary<string, ulong> URL;
        public ConcurrentDictionary<string, ulong> domainData;
        public ConcurrentDictionary<string, ulong> errorCodes;
        public LogStruct()
        {
            domainName = new ConcurrentDictionary<string, ulong> { };
            URL = new ConcurrentDictionary<string, ulong> { };
            domainData = new ConcurrentDictionary<string, ulong> { };
            errorCodes = new ConcurrentDictionary<string, ulong> { };
        }
    }
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
                        m_logStruct.URL.AddOrUpdate(fullAdress, 1, (key, oldVal) =>
                        {
                            m_logStruct.URL[fullAdress]++;
                            return m_logStruct.URL[fullAdress];
                        });
                        m_logStruct.errorCodes.AddOrUpdate(fullErrCode, 1, (key, oldVal) =>
                        {
                            m_logStruct.errorCodes[fullErrCode]++;
                            return m_logStruct.errorCodes[fullErrCode];
                        });
                    }
                    else
                    {
                        m_logStruct.domainName.AddOrUpdate(domainName, 1, ShallNeverHappen);
                        m_logStruct.domainData.AddOrUpdate(domainName, pageSize, ShallNeverHappen);
                        m_logStruct.URL.AddOrUpdate(fullAdress, 1, ShallNeverHappen);
                        m_logStruct.errorCodes.AddOrUpdate(fullErrCode, 1, ShallNeverHappen);
                    }
                }
            }
        }
        public ulong ShallNeverHappen(String key, ulong existingVal) 
        {
            throw new InvalidOperationException("This method is not expected to be called");
        }
    }
