public sealed class ContactViewModelValidator 
    : AbstractValidator<ContactViewModel>
{
    pulbic ContactViewModelValidator()
    {
        RuleFor(vm => vm.FirstName)
            .Required()
            .WithMessage("The first name is required");
        // more rules
    }
}
**ViewModel**
csharp
public sealed class ContactViewModel : ReactiveObject, ISupportsActivation
{
    public ViewModelActivator Activator { get; } = new ViewModelActivator();
    [Reactive] public string FirstName { get; set; }
    [Reactive] public string FirstNameErrorMessage { get; set; }
    // other properties
    private IValidator<ContactViewModel> Validator { get; }
    public ContactViewModel(IValidator<ContactViewModel> validator)
    {
        Validator = validator ?? throw new ArgumentNullException(nameof(validator));
         this.WhenActivated(d =>
         {
             ActivateValidation(this, d);
             // other activations
         });
    }
    // since this is static, you can put it in an external class
    private static void ActivateValidation(ContactViewModel viewModel, CompositeDisposable d)
    {
        var validationSubject = new Subject<ValidationResult>().DisposeWith(d);
        viewModel.WhenAnyValue(vm => vm.FirstName /* other properties */)
            .Select(_ => viewModel)
            .Select(viewModel.Validator.Validate)
            .ObserveOn(RxApp.MainThreadScheduler)
            .SubscribeOn(RxApp.MainThreadScheduler)
            .Subscribe(result => validationSubject.OnNext(result))
            .DisposeWith(d);
        validationSubject
            .Select(e => e.Errors)
            .ObserveOn(RxApp.MainThreadScheduler)
            .SubscribeOn(RxApp.MainThreadScheduler)
            .Subscribe(errors =>
            {
                using (viewModel.DelayChangeNotifications())
                {
                    viewModel.FirstNameErrorMessage = 
                        errors.GetMessageForProperty(nameof(viewModel.FirstName));
                    // handle other properties
                }
            })
            .DisposeWith(d);
    }
}
**Extensions**
csharp
public static class ValidationFailureExtensions
{
    // This is an example that gives you all messages,
    // no matter if they are warnings or errors.
    // Provide your own implementation that fits your need.
    public static string GetMessageForProperty(this IList<ValidationFailure> errors, string propertyName)
    {
        return errors
            .Where(e => e.PropertyName == propertyName)
            .Select(e => e.ErrorMessage)
            .Aggregate(new StringBuilder(), (builder, s) => builder.AppendLine(s), builder => builder.ToString());
    }
}
**View**
csharp
public partial class ContactControl : IViewFor<ContactViewModel>
{
    public ContactControl()
    {
        InitializeComponent();
    }
    object IViewFor.ViewModel
    {
        get => ViewModel;
        set => ViewModel = value as ContactViewModel;
    }
    public ContactViewModel ViewModel
    {
        get => DataContext as ContactiewModel;
        set => DataContext = value;
    }
}
xaml
d:DataContext="{d:DesignInstance Type=local:ContactViewModel, IsDesignTimeCreatable=True}" 
xaml
<UserControl.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="..." />
                <ResourceDictionary>
                    <Style BasedOn="{StaticResource {x:Type TextBlock}}" 
                           TargetType="TextBlock"
                           x:Key="ErrorMessageTextBlock">
                            <Style.Setters>
                                <Setter Property="Foreground" Value="Red" />
                                <Setter Property="Height" Value="Auto" />
                                <Setter Property="TextWrapping" Value="Wrap" />
                                <Setter Property="Padding" Value="4" />
                        </Style.Setters>
                            <Style.Triggers>
                                <Trigger Property="Text" Value="{x:Null}">
                                    <Setter Property="Height" Value="0" />
                                    <Setter Property="Visibility" Value="Collapsed" />
                                </Trigger>
                                <Trigger Property="Text" Value="">
                                    <Setter Property="Height" Value="0" />
                                    <Setter Property="Visibility" Value="Collapsed" />
                                </Trigger>
                            </Style.Triggers>
                    </Style>
                </ResourceDictionary>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </UserControl.Resources>
xaml
<TextBlock Text="{Binding FirstNameErrorMessage}"
           Style="{StaticResource ErrorMessageTextBlock}" />
