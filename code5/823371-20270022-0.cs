		public static void RunTestCalculator() {
			AntlrInputStream inputStream = new AntlrInputStream(@" 9 + 3 ");
			SimpleCalcLexer lex = new SimpleCalcLexer(inputStream);
			CommonTokenStream tokens = new CommonTokenStream(lex);
			SimpleCalcParser parser = new SimpleCalcParser(tokens);
			try {
				var theExpr = parser.expr();
				Console.WriteLine("found expr " + theExpr.ToString());
        var t = tokens.Get(0);
        Console.WriteLine("t = " + t.ToString());
			} catch (RecognitionException e) {
				System.Console.WriteLine("EXCEPTION:");
				System.Console.WriteLine(e.StackTrace);
			}
		}
