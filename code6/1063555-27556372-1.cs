    class Program
    {
        private class Bar
        {
            public string Name { get; set; }
            public int FirstX { get; set; }
            public int FirstY { get; set; }
            public int LastX { get; set; }
            public int LastY { get; set; }
        }
        static void Main(string[] args)
        {
            const string commandCreateBar1 = "CREATE bar NAMED bar_a FIRST(5,10) LAST (15,20)";
            const string commandCreateBar2 = "CREATE bar NAMED MyFooBar FIRST(25  ,  31)    LAST   (153 ,210)";
            const string commandCreateBar3 = "CREATE    bar   NAMED    MySpaceyFooBar FIRST(0,0)  LAST (12,39)";
            Bar bar1 = ParseCreateBar(commandCreateBar1);
            PrintBar(bar1);
            Bar bar2 = ParseCreateBar(commandCreateBar2);
            PrintBar(bar2);
            Bar bar3 = ParseCreateBar(commandCreateBar3);
            PrintBar(bar3);
        }
        private static void PrintBar(Bar bar)
        {
            Console.WriteLine("A new bar was Created! \"{0}\" ({1}, {2}) ({3}, {4})", bar.Name, bar.FirstX, bar.FirstY, bar.LastX, bar.LastY);
        }
        private static Bar ParseCreateBar(string commandLine)
        {
            var bar = new Bar();
            var parser = new TokenParser { InputString = commandLine };
            Expect(parser, TokenParser.Tokens.CREATE);
            Expect(parser, TokenParser.Tokens.BAR);
            Expect(parser, TokenParser.Tokens.NAMED);
            Token token = Expect(parser, TokenParser.Tokens.BAR_NAME);
            bar.Name = token.TokenValue;
            Expect(parser, TokenParser.Tokens.FIRST);
            Expect(parser, TokenParser.Tokens.LPAREN);
            token = Expect(parser, TokenParser.Tokens.NUMBER);
            bar.FirstX = int.Parse(token.TokenValue);
            Expect(parser, TokenParser.Tokens.COMMA);
            token = Expect(parser, TokenParser.Tokens.NUMBER);
            bar.FirstY = int.Parse(token.TokenValue);
            Expect(parser, TokenParser.Tokens.RPAREN);
            Expect(parser, TokenParser.Tokens.LAST);
            Expect(parser, TokenParser.Tokens.LPAREN);
            token = Expect(parser, TokenParser.Tokens.NUMBER);
            bar.LastX = int.Parse(token.TokenValue);
            Expect(parser, TokenParser.Tokens.COMMA);
            token = Expect(parser, TokenParser.Tokens.NUMBER);
            bar.LastY = int.Parse(token.TokenValue);
            Expect(parser, TokenParser.Tokens.RPAREN);
            return bar;
        }
        private static Token Expect(TokenParser parser, TokenParser.Tokens expectedToken)
        {
            EatWhiteSpace(parser);
            Token token = parser.GetToken();
            if (token != null && token.TokenName != expectedToken)
            {
                Console.WriteLine("Expected Token " + expectedToken);
                Environment.Exit(0);
            }
            if (token == null)
            {
                Console.WriteLine("Unexpected end of input!");
                Environment.Exit(0);
            }
            return token;
        }
        private static void EatWhiteSpace(TokenParser parser)
        {
            while (parser.Peek() != null && parser.Peek().TokenPeek != null && 
                parser.Peek().TokenPeek.TokenName == TokenParser.Tokens.WHITESPACE)
            {
                parser.GetToken();
            }
        }
    }
