    public static bool Demonstrate<T>(T x)
    {
      T y = default(T);
      bool isNull = x == null;
      bool isDefault = x.Equals(default(T));
      int zero = default(int)
      return zero == default(int);
    }
    Public Shared Function Demonstrate(Of T)(x As T) As Boolean
      Dim y As T = Nothing
      Dim isNull As Boolean = x Is Nothing
      Dim isDefault As Boolean = x.Equals(Nothing)
      Dim zero As Integer = Nothing
      Return zero = Nothing
    End Function
