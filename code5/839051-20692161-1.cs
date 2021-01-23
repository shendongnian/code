        [Test]
        public void Test()
        {
            string fullString = "group = '2843360' and (team in ('TEAM1', 'TEAM2','TEAM3'))";
            var resultParser =
                from @group in OperatorEquals("group")
                from @and in OperatorEnd()
                from @team in Brackets(OperatorIn("team"))
                select new {@group, @team};
            var result = resultParser.Parse(fullString);
            Assert.That(result.group, Is.EqualTo("2843360"));
            Assert.That(result.team, Is.EquivalentTo(new[] {"TEAM1", "TEAM2", "TEAM3"}));
        }
        private static readonly Parser<char> CellSeparator =
            from space1 in Parse.WhiteSpace.Many()
            from s in Parse.Char(',')
            from space2 in Parse.WhiteSpace.Many()
            select s;
        private static readonly Parser<char> QuoteEscape = Parse.Char('\\');
        private static Parser<T> Escaped<T>(Parser<T> following)
        {
            return from escape in QuoteEscape
                   from f in following
                   select f;
        }
        private static readonly Parser<char> QuotedCellDelimiter = Parse.Char('\'');
        private static readonly Parser<char> QuotedCellContent =
            Parse.AnyChar.Except(QuotedCellDelimiter).Or(Escaped(QuotedCellDelimiter));
        private static readonly Parser<string> QuotedCell =
            from open in QuotedCellDelimiter
            from content in QuotedCellContent.Many().Text()
            from end in QuotedCellDelimiter
            select content;
        private static Parser<string> OperatorEquals(string column)
        {
            return
                from c in Parse.String(column)
                from space1 in Parse.WhiteSpace.Many()
                from opEquals in Parse.Char('=')
                from space2 in Parse.WhiteSpace.Many()
                from content in QuotedCell
                select content;
        }
        private static Parser<bool> OperatorEnd()
        {
            return
                from space1 in Parse.WhiteSpace.Many()
                from c in Parse.String("and")
                from space2 in Parse.WhiteSpace.Many()
                select true;
        }
        private static Parser<T> Brackets<T>(Parser<T> contentParser)
        {
            return from open in Parse.Char('(')
                   from space1 in Parse.WhiteSpace.Many()
                   from content in contentParser
                   from space2 in Parse.WhiteSpace.Many()
                   from close in Parse.Char(')')
                   select content;
        }
        private static Parser<IEnumerable<string>> ComaSeparated()
        {
            return from leading in QuotedCell
                   from rest in CellSeparator.Then(_ => QuotedCell).Many()
                   select Cons(leading, rest);
        }
        private static Parser<IEnumerable<string>> OperatorIn(string column)
        {
            return
                from c in Parse.String(column)
                from space1 in Parse.WhiteSpace
                from opEquals in Parse.String("in")
                from space2 in Parse.WhiteSpace.Many()
                from content in Brackets(ComaSeparated())
                from space3 in Parse.WhiteSpace.Many()
                select content;
        }
        private static IEnumerable<T> Cons<T>(T head, IEnumerable<T> rest)
        {
            yield return head;
            foreach (T item in rest)
                yield return item;
        }
        
       
