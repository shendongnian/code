    myQueryable.Select(
        x => new ExtendedMyClass
        {
            MyObject = x,
            ExtraFieldValues =
                new[]
                {
                    new StringAndBool { FieldName = "Foo", IsTrue = x.Foo },
                    new StringAndBool { FieldName = "Bar", IsTrue = x.Bar }
                }
        });
