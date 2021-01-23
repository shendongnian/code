     public override bool Equals(object obj)
        {
          if (obj == null)
            return false;
          RuntimeType runtimeType = (RuntimeType) this.GetType();
          if ((RuntimeType) obj.GetType() != runtimeType)
            return false;
          object a = (object) this;
          if (ValueType.CanCompareBits((object) this))
            return ValueType.FastEqualsCheck(a, obj);
          FieldInfo[] fields = runtimeType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
          for (int index = 0; index < fields.Length; ++index)
          {
            object obj1 = ((RtFieldInfo) fields[index]).UnsafeGetValue(a);
            object obj2 = ((RtFieldInfo) fields[index]).UnsafeGetValue(obj);
            if (obj1 == null)
            {
              if (obj2 != null)
                return false;
            }
            else if (!obj1.Equals(obj2))
              return false;
          }
          return true;
        }
