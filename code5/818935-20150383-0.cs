    var statements = session.Query<TBAStatementBankAccount>().Where(x => x.TBABankAccount == bankAccount).ToList().Select(x => x.TBAStatement).ToList();
     var sublists = statements
                    .Select((x, i) => new { Index = i, Value = x })
                    .GroupBy(x => x.Index / 2000)
                    .Select(x => x.Select(v => v.Value).ToList())
                    .ToArray();
    
                List<TBAStatement> lstNewstatement = new List<TBAStatement>();
                foreach (var statemnt in sublists)
                {            
                    var state = session.Query<TBAStatement>().Where(x => statemnt.Contains(x) && x.FDate < CutOffDate).ToList();
                    lstNewstatement.AddRange(state);
                }
