    query.Select(
        ... // all the GROUP BY statements
        // the total row count
        Projections.SqlProjection(" COUNT(*) OVER() AS TotalRowCount "
                       , new string[] { "TotalRowCount" }
                       , new IType[] { NHibernateUtil.Int32 })
        // count, sum
        Projections.Count<IssuanceReportLogEntity>(x=>x.RecipientGroupId)
                   .WithAlias(()=>receiver.RecognitionTotalReceived),
        Projections.Sum<IssuanceReportLogEntity>(x=>x.Points)
                   .WithAlias(()=>receiver.TotalPoints)
    );
