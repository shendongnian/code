	public class CanSetSpecificSetting : CanSetSettings<SetSpecificSettings>, IValidationhandler<SetSpecificSettings>
	{
		public CanSetSpecificSetting (IFooRepository repo)
		: base(repo)
		{ }
		public override ICollection<ValidationResult> Validate(SetSpecificSettings command)
		{
			BaseValidate(command); // << Instead of calling base.Validate(command).
			// ... other logic here
			return results;
		}
		
        // This is the template method. You MUST declare it as virtual.
		protected virtual ICollection<ValidationResult> BaseValidate(SetSpecificSettings command)
		{
			return base.Validate(command);
		}
	}
