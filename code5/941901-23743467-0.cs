    public class JournalEntryItemMap : ClassMap<JournalEntryItem>
    {
        public JournalEntryItemMap()
        {
            CompositeId()
                .KeyReference(x => x.JournalEntry, map => map.Access.CamelCaseField(Prefix.Underscore));
        }
    }
 
