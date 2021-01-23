       public Stream GetMyResource( MyResources myRes )
       {
          string actualResource = myRes.ToString().Replace( "_", "." );
          // This would convert the sample enums above to
          // EmptyZipTest.EmptyZipFile.zip,
          // EmptyZipTest.SomeOtherFile.jpg,
          // EmptyZipTest.AnotherFile.ini
       }
