    void Abc(int tagList)
        {
            var sourceLists = new List<Demo>
                {
                  new Demo { FTerminal = "200", TagNo = 1000 },
                  new Demo { FTerminal = "300", TagNo = 1000 },
                  new Demo { FTerminal = "400", TagNo = 1000 }
                };
    
            var terminalList = sourceLists.Where(t => t.TagNo == tagList && t.FTerminal.Length > 0).OrderBy(i=>i.FTerminal).GroupBy(i=>i.TagNo);                                                               
                                  
        }
