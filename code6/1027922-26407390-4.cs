    public class Field
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Field NextTaskTemplateField { get; set; }
        public virtual Field PreviousTaskTemplateField { get; set; }
    }
