        var test = from alts in alternatives
                   from alt in alts
                   group alts by new { MemberId = alt.Member.Id, OriginalClaimId = alt.OriginalClaim.Id } into a
                   select a;
        foreach (var a in test)
        {
            Console.WriteLine("Auth {0}", a.Key.OriginalClaimId);
            Console.WriteLine("MemberId {0}", a.Key.MemberId);
            foreach (var alt in a.SelectMany(x => x))
                [write out alt.AltClaim properties in console here]
        }
