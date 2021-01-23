    // PopupViewModel.cs
    internal sealed class PopupViewModel
    {
        public PopupViewModel(string message)
        {
            Message = message;
        }
        public string Message { get; }
    }    
    // PopupView.xaml
    <UserControl …>
        <Grid DataContext="{Binding Content, Mode=OneTime}">
            <Label Text="{Binding Message, Mode=OneTime}" />
        </Grid>
    </UserControl>
    // SomeViewModel.cs
    internal sealed class SomeViewModel
    {
        // Don't use DI-container references to construct objects, inject factories instead.
        // Also to keep things simple you can just create your PopupViewModel directly if it has no external dependencies.
        private readonly Func<string, PopupViewModel> _popupViewModelFactory;
        public SomeViewModel(Func<string, PopupViewModel> popupViewModelFactory)
        {
            _popupViewModelFactory = popupViewModelFactory;
        }
        public ICommand ShowPopupCommand { get; } = new DelegateCommand(DoShowPopup);
        public InteractionRequest<INotification> PopupRequest { get; } = new InteractionRequest<INotification>();
        private void DoShowPopup()
        {
            PopupRequest.Raise(new Notification
            {
                Content = _popupViewModelFactory("This is a Popup Message!")
            }, _ =>
            {
                // Callback code.
            });
        }
    }
    // SomeView.xaml
    <UserControl …>
        <i:Interaction.Triggers>
            <prism:InteractionRequestTrigger SourceObject="{Binding PopupRequest, Mode=OneTime}">
                <prism:PopupWindowAction WindowContentType="views:PopupView" />
            </prism:InteractionRequestTrigger>
        </i:Interaction.Triggers>
        <Button Command="{Binding ShowPopupCommand, Mode=OneTime}" />
    <UserControl>
    // SomeModule.cs (or maybe Bootstrapper.cs if you setup your container in Bootstrapper)
    public sealed class SomeModule : IModule
    {
        private readonly IUnityContainer _container;
        public SomeModule(IUnityContainer container)
        {
            _container = container;
        }
        public override void Initialize()
        {
            _container.RegisterType<Func<string, PopupViewModel>>(
                new InjectionFactory(c =>
                    new Func<string, PopupViewModel>(message =>
                        c.Resolve<PopupViewModel>(
                            new ParameterOverride("message", message))));
        }
    }
