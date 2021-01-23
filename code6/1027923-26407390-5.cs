    public class FieldMap : ClassMap<Field>
    {
        public FieldMap()
        {
            Table("Field");
            Id(f => f.Id).Column("FieldId");
            Map(f => f.Name);
            References(f => f.NextTaskTemplateField)
                .Column("NextTaskTemplateFieldId");
            References(f => f.PreviousTaskTemplateField)
                .Column("PreviousTaskTemplateFieldId");
        }
    }
