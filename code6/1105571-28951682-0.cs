            var alts = alternatives.SelectMany(x => x);
            var res = alts.GroupBy(alt => Tuple.Create(alt.Member, alt.OriginalClaim))
                .Select(g => new Alternative
                {
                    Member = g.Key.Item1,
                    OriginalClaim = g.Key.Item2,
                    AlternativeClaims = g.Select(x => new AlternativeClaim {AltClaim = x.AltClaim, Savings = x.Savings}).ToList()
                });
            foreach (var a in res)
            {
                Console.WriteLine("Auth {0}", a.OriginalClaim.Id);
                Console.WriteLine("MemberId {0}", a.Member.Id);
                foreach (var alt in a.AlternativeClaims.OrderByDescending(c => c.Savings))
                {
                    Console.WriteLine("\tSavings = {0};Id = {1};",alt.Savings, alt.AltClaim.Id);
                }
            }
