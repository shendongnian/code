    // instead of this
    // resulting in INNER JOIN
    query.JoinAlias(root => root.InnerObject, () => innerObjectAlias);
    // we must use this
    query.JoinAlias(root => root.InnerObject, () => innerObjectAlias
                  , JoinType.LeftOuterJoin);
    // which will result in LEFT OUTER JOIN
