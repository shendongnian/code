    public class CustomProviderHelper : IdeaBlade.Rdb.OleDbProviderHelper {
      public override string FormatIdentifier(string identifier) {
        return identifier;
      }
    }
