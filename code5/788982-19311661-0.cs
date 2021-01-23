    public class SecurityQuestionsSection: ConfigurationSection
	{
		[ConfigurationProperty("questions", IsRequired = true, IsDefaultCollection = true)]
		public QuestionCollection Questions
		{
			get
			{
				return (QuestionCollection)base["questions"];
			}
		}
	}
