    public static T GetValueAt<T>(int idx)
    {
      var vals = Enum.GetValues(typeof(T));
      return (T)vals.GetValue(idx);
    }
