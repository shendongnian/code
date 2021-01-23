    public static class TestStore
    {
        public static void Test()
        {
            string xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
    <store>
      <authors>
       <author id=""PK"">
         <name>Philip Kindred</name>
        </author>
      </authors>
      <books>
        <book id=""u1"">
          <author>PK</author> <!--  use only ID -->
          <title>Ubik</title>
        </book>
      </books>
    </store>
    ";
            var store = xml.LoadFromXML<Store>();
            Debug.Assert(store.BookList[0].Author == store.AuthorList[0]); // no assert
        }
    }
