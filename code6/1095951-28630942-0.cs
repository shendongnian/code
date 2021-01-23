    public class ViewModelValidator : AbstractValidator<ViewModel> {
    	public MyViewModelValidator() {
    		RuleFor(x => x.Minimum).NotNull();
    		RuleFor(x => x.Maximum).NotNull.Length(0, 10);
    	}
    }
