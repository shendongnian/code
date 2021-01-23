    var tag = documentStore.Conventions.GetTypeTagName(typeof(YourDataType));
    var myDataObjects = session.Advanced
                     .LuceneQuery<IEntity, RavenDocumentsByEntityName>()
                     .WhereEquals("Tag", tag)
                     .AndAlso()
                      //....
