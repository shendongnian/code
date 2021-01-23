    List<CustomClass> toUpdate = ...
    var query = string.Format(@"
        UPDATE table 
        SET processed = CASE {0} ELSE 1/0 END
        WHERE id IN ({1})
        ",
        string.Join(
            " ",
            toUpdate.GroupBy(c => c.Status)
                .Select(g => string.Format("WHEN id IN ({0}) THEN {1}", g.Key, string.Join(",", g.Select(c => c.ID))
        ),
        string.Join(",", toUpdate.Select(c => c.ID))
    );
