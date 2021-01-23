    public class Resolver {
      public Data GetData () {
        return new Data { Email = new Mail().Obfuscate(myEmail, Translate) };
      }
      public String Translate(string value) { /* Some Code */ }
    }
