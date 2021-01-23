c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc()
        .AddDataAnnotationsLocalization(options => {
            options.DataAnnotationLocalizerProvider = (type, factory) =>
                factory.Create(typeof(SharedResource));
        });
}
So for this model:
c#
public class RegisterViewModel
{
    [Required(ErrorMessage = "The Email field is required.")]
    [EmailAddress(ErrorMessage = "The Email field is not a valid email address.")]
    [Display(Name = "Email")]
    public string Email { get; set; }
}
You'd add a resx file in one of the following locations:
- _Resources/ViewModels.Account.RegisterViewModel.fr.resx_
- _Resources/ViewModels/Account/RegisterViewModel.fr.resx_
