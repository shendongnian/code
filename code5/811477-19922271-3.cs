    void Abc(int tagList)
    {
        var sourceLists = new List<Demo>
            {
              new Demo { FTerminal = "200", TagNo = 1000 },
              new Demo { FTerminal = "300", TagNo = 1000 },
              new Demo { FTerminal = "400", TagNo = 1000 }
            };
        var terminalList = 
            from Demo d in sourceLists
                where d.TagNo == tagList
                let number = int.Parse(d.FTerminal)
                orderby number ascending
                select number).ToList();
    }
