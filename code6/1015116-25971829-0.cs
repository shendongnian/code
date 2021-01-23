    public virtual void WriteValue(object value)
        {
          if (value == null)
          {
            WriteNull();
            return;
          }
          else if (value is IConvertible)
          {
            IConvertible convertible = value as IConvertible;
     
            switch (convertible.GetTypeCode())
            {
              case TypeCode.String:
                WriteValue(convertible.ToString(CultureInfo.InvariantCulture));
                return;
              case TypeCode.Char:
                WriteValue(convertible.ToChar(CultureInfo.InvariantCulture));
                return;
              case TypeCode.Boolean:
                WriteValue(convertible.ToBoolean(CultureInfo.InvariantCulture));
                return;
              case TypeCode.SByte:
                WriteValue(convertible.ToSByte(CultureInfo.InvariantCulture));
                return;
              case TypeCode.Int16:
                WriteValue(convertible.ToInt16(CultureInfo.InvariantCulture));
                return;
              case TypeCode.UInt16:
                WriteValue(convertible.ToUInt16(CultureInfo.InvariantCulture));
                return;
              case TypeCode.Int32:
                WriteValue(convertible.ToInt32(CultureInfo.InvariantCulture));
                return;
              case TypeCode.Byte:
                WriteValue(convertible.ToByte(CultureInfo.InvariantCulture));
                return;
              case TypeCode.UInt32:
                WriteValue(convertible.ToUInt32(CultureInfo.InvariantCulture));
                return;
              case TypeCode.Int64:
                WriteValue(convertible.ToInt64(CultureInfo.InvariantCulture));
                return;
              case TypeCode.UInt64:
                WriteValue(convertible.ToUInt64(CultureInfo.InvariantCulture));
                return;
              case TypeCode.Single:
                WriteValue(convertible.ToSingle(CultureInfo.InvariantCulture));
                return;
              case TypeCode.Double:
                WriteValue(convertible.ToDouble(CultureInfo.InvariantCulture));
                return;
              case TypeCode.DateTime:
                WriteValue(convertible.ToDateTime(CultureInfo.InvariantCulture));
                return;
              case TypeCode.Decimal:
                WriteValue(convertible.ToDecimal(CultureInfo.InvariantCulture));
                return;
              case TypeCode.DBNull:
                WriteNull();
                return;
            }
          }
    #if !PocketPC && !NET20
          else if (value is DateTimeOffset)
          {
            WriteValue((DateTimeOffset)value);
            return;
          }
    #endif
          else if (value is byte[])
          {
            WriteValue((byte[])value);
            return;
          }
     
          throw new ArgumentException("Unsupported type: {0}. Use the JsonSerializer class to get the object's JSON representation.".FormatWith(CultureInfo.InvariantCulture, value.GetType()));
        }
