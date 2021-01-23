    [Table("Form")]
    public class Form : IEntity
    {
        [Key, Column("FormID")]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        public ICollection<FormField> FormFields { get; set; }
    }
    [Table("FormField")]
    public class FormField : IEntity
    {
        [Key, Column("FormFieldID", Order = 0)]
        public int Id { get; set; }
        [Key, Column(Order = 1)]
        public FieldType FieldType { get; set; }
        [ForeignKey("Form")]
        public int FormId { get; set; }
        public int OrderNo { get; set; }
        public virtual Form Form { get; set; }
        public virtual AddressField AddressField { get; set; }
        public virtual ChoiceField ChoiceField { get; set; }
        public virtual DateTimeField DateTimeField { get; set; }
	// etc
    }
    [Table("ChoiceField")]
    public class ChoiceField : BaseField, IEntity
    {
        [Key, ForeignKey("FormField"), Column("FormFieldID", Order = 0)] // these keys are for parent FormField table
        public int Id { get; set; }
        [Key, ForeignKey("FormField"), Column(Order = 1)]
        public FieldType FieldType { get; set; }
        public virtual FormField FormField { get; set; }
        public ICollection<ChoiceFieldOption> ChoiceFieldOptions { get; set; }
    }
    [Table("ChoiceFieldOption")]
    public class ChoiceFieldOption : IEntity
    {
        [Key, Column("ChoiceFieldOptionID")]
        public int Id { get; set; }
        [ForeignKey("ChoiceField")] // this FK are bound to simple ChoiceField.Id key defined in fluent API
        public int ChoiceFieldId { get; set; }
        [Required, StringLength(50)]
        public string Option { get; set; }
        public int OrderNo { get; set; }
        public virtual ChoiceField ChoiceField { get; set; }
    }
...
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Form>();
            var eFormField = modelBuilder.Entity<FormField>();
            var eChoiceField = modelBuilder.Entity<ChoiceField>();
	    // here I add a second Key for ChoiceField table
            eChoiceField.HasKey(cf => new { cf.Id });
            var eChoiceFieldOption = modelBuilder.Entity<ChoiceFieldOption>();
            modelBuilder.Entity<AddressField>();
            modelBuilder.Entity<DateTimeField>();
	    // ...
        }
            
