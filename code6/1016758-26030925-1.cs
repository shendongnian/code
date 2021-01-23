	public class SurveyViewModel : INotifyPropertyChanged
	{
		private Survey _survey;
		
		public Survey Survey
		{
			get { return _survey; }
			set
            {
				_survey = value;
				RaisePropertyChanged(() => Survey);
			}
		}
		
		public void ModifySurvey()
		{
			// Modify a property of the model.
			Survey.FirstName = "Modified";
			// Make other modifications here...
			// Notify property changed
			RaisePropertyChanged(() => Survey);
		}
	}
