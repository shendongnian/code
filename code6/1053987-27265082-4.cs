    public class Person
    {
        ... as above
        public virtual IList<PersonRelation> Parents { get; set; }
    HasMany<PersonRelation>(x => x.Parents)
        // instead of this
        // .KeyColumn("PersonIdA")
        // we need this column
        .KeyColumn("PersonIdB")
    ;
     
