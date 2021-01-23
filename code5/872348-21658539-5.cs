    public class RegisterApplicationIoC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmailSenderToDebug>()
                   .As<IEmailSender>()
                   .InstancePerHttpRequest();
        }
    }
