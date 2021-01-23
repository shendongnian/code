    public class TestIndex : AbstractIndexCreationTask<CardApplication>
    {
       public TestIndex()
       {
            Map = apps =>
                from app in apps
                select new { State = app.State, IdentityDetails_Applicant_FirstName = app IdentityDetails.Applicant.FirstName};
    
            Sort(c => c.State, Raven.Abstractions.Indexing.SortOptions.String);
     Store("IdentityDetails_Applicant_FirstName", FieldStorage.Yes);
       }
    }
