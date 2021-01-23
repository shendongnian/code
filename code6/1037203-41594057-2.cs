    public static Func<String, TEnum> GetParseEnumDelegate<TEnum>()
    {
      var eValue = Expression.Parameter(typeof(String), "value"); // (String value)
      var tEnum = typeof(TEnum);
      return
        Expression.Lambda<Func<String, TEnum>>(
          Expression.Block(tEnum,
            Expression.Switch(tEnum, eValue,
              Expression.Block(tEnum,
                Expression.Throw(Expression.New(typeof(Exception).GetConstructor(Type.EmptyTypes))),
                Expression.Default(tEnum)
              ),
              null,
              Enum.GetValues(tEnum).Cast<Object>().Select(v => Expression.SwitchCase(
                Expression.Constant(v),
                Expression.Constant(v.ToString())
              )).ToArray()
            )
          ), eValue
        ).Compile();
    }
    ...
	var parseEnum = GetParseEnumDelegate<YourEnum>();
	YourEnum e = parseEnum("SomeEnumValue");
