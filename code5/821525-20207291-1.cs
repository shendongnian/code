     public class YOURContext: DbContext{
 
     protected override void OnModelCreating(DbModelBuilder modelBuilder) {
     // here is where fluent API goes.
     // I suspected the error is EF wanting a NO cascade delete. Hence the suggestion to try
     entity<Booking>.HasOptional(t => t.Bunk) 
                  .WithOptionalPrincipal()
                  .WillCascadeOnDelete(false);      // <<<<<< this is the option to try.
     // you may also need to try the same with Preferred_Room as well.
