    public class SP
    {
      [Microsoft.SqlServer.Server.SqlFunction(IsDeterministic = true)]
      public static SqlString Enc(SqlString TextToEncrypt)
      {
         return DoSomething(TextToEncrypt.Value);
      }
    }
