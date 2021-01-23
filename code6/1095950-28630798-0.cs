	public class ViewModel : IValidatableObject
	{
		[Required]
		public int? Minimum { get; set; }
		[Required]
		public int? Maximum { get; set; }
		
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var results = new List<ValidationResult>();
			
			if (this.Minimum > this.Maximum)
			{
				results.Add(new ValidationResult("Maximum must be larger than Minimum"));
			}
			
			return results;
		}
	}
