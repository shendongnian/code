    [Export(typeof (IShell))]
    public class ShellViewModel : Conductor<IScreen>
    {
        public ShellViewModel()
        {
            DisplayName = "Your window title";
        }
    }
