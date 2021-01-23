    public class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
			/* all other mapping info */
            References<User>(x => x.Wants)
                .Class(typeof(User))
                /*.Not.Nullable() */
                 .Nullable()
                .Column("WantsUserUUID")
                .Index("IX_Book_WantsUserUUID")
                .Cascade.SaveUpdate()
                ;
            ;
            References<User>(x => x.Read )
                .Class(typeof(User))
                /*.Not.Nullable() */
                 .Nullable()
                .Column("ReadUserUUID")
                .Index("IX_Book_ReadUserUUID")
                .Cascade.SaveUpdate()
                ;
            ;
