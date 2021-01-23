     public static TRet FieldWithAttribute<TAttr, TRet>(this object obj) where TAttr : Attribute
     {
          var field = obj.GetType()
                .GetProperties()
                .SingleOrDefault(x => Attribute.IsDefined(x, typeof (TAttr)));
            return field == null ? default(TRet) : (TRet)field.GetValue(obj);
     }
