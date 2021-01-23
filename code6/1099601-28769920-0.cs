    // text part as projection
    var textPart = Projections.SqlProjection(
        "LEFT(Code, IIF( PATINDEX('%[0-9]%', Code) > 0, PATINDEX('%[0-9]%', Code) - 1, 0)) AS [TXT]"
        , new string[] {}
        , new IType[] {}
        );
    // number part as projection
    var numberPart = Projections.SqlProjection(
        " ISNULL(TRY_PARSE(SUBSTRING(Code, (PATINDEX('%[0-9]%', Code)), LEN(Code)) as int), 0) AS [NUM]"
        , new string[] {}
        , new IType[] {}
        );
            ;
    var criteria = session
          .CreateCriteria<Item>()
          .Add(Restrictions.InsensitiveLike("Code", code + "%"));
    var items = criteria
          // here we order by our projectons
          .AddOrder(Order.Asc(textPart))
          .AddOrder(Order.Asc(numberPart))
          .List<Item>();
