    public static Func<String, Object> GetParseEnumDelegate(Type tEnum)
    {
      var eValue = Expression.Parameter(typeof(String), "value"); // (String value)
      var tReturn = typeof(Object);
      return
        Expression.Lambda<Func<String, Object>>(
          Expression.Block(tReturn,
            Expression.Convert( // We need to box the result (tEnum -> Object)
              Expression.Switch(tEnum, eValue,
                Expression.Block(tEnum,
                  Expression.Throw(Expression.New(typeof(XException).GetConstructor(Type.EmptyTypes))),
                  Expression.Default(tEnum)
                ),
                null,
                Enum.GetValues(tEnum).Cast<Object>().Select(v => Expression.SwitchCase(
                  Expression.Constant(v),
                  Expression.Constant(v.ToString())
                )).ToArray()
              ), tReturn
            )
          ), eValue
        ).Compile();
    }
