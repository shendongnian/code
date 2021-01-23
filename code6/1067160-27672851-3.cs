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
        <book id=""t1"">
          <author>PK</author> <!--  use only ID -->
          <title>The Transmigration of Timothy Archer</title>
        </book>
      </books>
    </store>
    ";
            var store = xml.LoadFromXML<Store>();
            Debug.Assert(store.BookList[0].Author == store.AuthorList[0]); // no assert
            Debug.Assert(store.BookList[1].Author == store.AuthorList[0]); // no assert; verify that all books use the same instance of the `Author` class.
        }
    }
