        public CDBFileParser getFileParser(String cdbFilePath)
        {
            Stream stream                = File.OpenRead(cdbFilePath);
            AntlrInputStream inputStream = new AntlrInputStream(stream);
            CDBFileLexer lexer           = new CDBFileLexer(inputStream);            
            CommonTokenStream tokens     = new CommonTokenStream(lexer);
            CDBFileParser parser         = new CDBFileParser(tokens);
            try
            {
                CDBFileParserListener listener = new CDBFileParserListener();
                parser.AddParseListener(listener);
                System.Diagnostics.Debug.WriteLine(parser.parseCDBFile().ToStringTree());
                Dictionary<String, Module> modules = listener.Modules;
                Module main;
                modules.TryGetValue("main", out main);
                long line = main.getLineFromAddress(0xC09C);
                Console.WriteLine("0xC09C maps to " + line + " in  main.c");
            }
            catch (Exception e)
            {
                printException(e);
            }
            return parser;
        }
