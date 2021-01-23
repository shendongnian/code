      public static class Extensions {
        private static long EnumToLong(Object value) {
          if (Object.ReferenceEquals(null, value))
            return 0;
    
          Type type = value.GetType();
    
          if (!type.IsEnum)
            return 0;
    
          Type baseType = Enum.GetUnderlyingType(type);
    
          if (baseType == typeof(long))
            return (long) (value);
          else if (baseType == typeof(ulong))
            return (long) ((ulong) value);
          else if (baseType == typeof(uint))
            return (long) ((uint) value);
          else if (baseType == typeof(int))
            return (long) ((int) value);
          else if (baseType == typeof(short))
            return (long) ((short) value);
          else if (baseType == typeof(ushort))
            return (long) ((ushort) value);
          else if (baseType == typeof(byte))
            return (long) ((byte) value);
          else if (baseType == typeof(sbyte))
            return (long) ((sbyte) value);
    
          return 0;
        }
    
        private static List<T> CoreAsList<T>(Enum value) {
          // Has [Flags] attribute?
          Boolean hasFlagAttribute = false;
    
          Object[] attrs = typeof(T).GetCustomAttributes(true);
    
          for (int i = attrs.GetLowerBound(0); i <= attrs.GetUpperBound(0); ++i)
            if (attrs[i] is FlagsAttribute) {
              hasFlagAttribute = true;
    
              break;
            }
    
          List<T> result = new List<T>();
          HashSet<long> hs = new HashSet<long>();
    
          foreach (var item in Enum.GetValues(typeof(T))) {
            long v = EnumToLong(item);
            long all = EnumToLong(value);
    
            if (hs.Contains(v))
              continue;
    
            hs.Add(v);
    
            if ((all & v) == v)
              if (Enum.IsDefined(typeof(T), item))
                if (!((v == 0) && (hasFlagAttribute)))
                  result.Add((T) item);
          }
    
          return result;
        }
    
        /// <summary>
        /// You extension
        /// </summary>
        public static List<Foo> AsList(this Foo types) {
          return CoreAsList<Foo>(types);
        }
      }
