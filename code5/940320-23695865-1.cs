    private static void Validate(MemberController controller, object entityToValidate)
		{
			var valResults = TryValidate(entityToValidate);
			SetErrorInModelState(valResults, controller);
		}
		internal static Collection<ValidationResult> TryValidate(object entityToValidate)
		{
			var result = new Collection<ValidationResult>();
			Validator.TryValidateObject(entityToValidate, new ValidationContext(entityToValidate, null, null), result, true);
			return result;
		}
		internal static void SetErrorInModelState(Collection<ValidationResult> validationErrors, Controller controller)
		{
			foreach (var validationError in validationErrors)
			{
				controller.ModelState.AddModelError(validationError.MemberNames.First(), validationError.ErrorMessage);
			}
		}
