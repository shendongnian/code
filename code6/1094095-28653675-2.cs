	//usage
	public class SomeCommandHandler
	{
		private readonly IValidatorRuner<OneValdiationRuleExplicitlyExposedAndEasyToTest> _validatorRuner;
		public SomeCommandHandler(IValidatorRuner<OneValdiationRuleExplicitlyExposedAndEasyToTest> validatorRuner)
		{
			_validatorRuner = validatorRuner;
		}
		public void SomeMethod()
		{
			_validatorRuner.Run(new Person{Age = 16});
		}
	}
