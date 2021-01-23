    public class ViewModelValidator : AbstractValidator<ViewModel> {
    	public ViewModelValidator() {
    		RuleFor(x => x.Minimum).NotNull();
    		RuleFor(x => x.Maximum).NotNull.GreaterThan(x => x.Minimum)
    	}
    }
