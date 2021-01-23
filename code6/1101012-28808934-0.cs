    public int CompareTo(object obj)
            {
                if (obj is CustomDateClass)
                {
                    DateTime dt = ((CustomDateClass)obj).DateProperty;
                    return dt.CompareTo(DateProperty);
                }
                  throw new ArgumentException("not CustomDateClass");
            }
