    public class SaveModel {
        [Required]
        public AssigneeType? AssigneeType { get; set; }
        
        [RequiredForAny(Values = new[] { nameof(AssigneeType.Salesman) }, PropertyName = nameof(AssigneeType))]
        public Guid? AssigneeId { get; set; }
    }
