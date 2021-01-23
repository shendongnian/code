    if (!string.IsNullOrEmpty(aParam))
    {
        sqlBuilder.Append(" AND A LIKE :aParam");
    }
    if (!string.IsNullOrEmpty(bParam))
    {
        sqlBuilder.Append(" AND B LIKE :bParam");
    }
