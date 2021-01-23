        private void RunParser(string text)
        {
            var input = new AntlrInputStream(text);
            var lexer = new MetaMetaLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new MetaMetaParser(tokens);
            var context = parser.prog();
            var visitor = new MyVisitor();
            visitor.Visit(context); //changed to just Visit
        }
