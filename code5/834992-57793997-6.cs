    public class ShowAllWindowRule : IWindowRule
    {
        public string Command => "Show commands";
        private ProgramCommands _progCommands;
        public ShowAllWindowRule(ProgramCommands programCommands) =>
              _progCommands = programCommands;
        public void Invoke() => _progCommands.ShowAllCommands();
    }
    public class CloseWindowRule : IWindowRule
    {
        private ControlCommands _ctrlCommands;
        public string Command => "Close window";
        public CloseWindowRule(ControlCommands ctrlCommands) =>
            _ctrlCommands = ctrlCommands;
        public void Invoke() =>
            _ctrlCommands.CloseWindow();
    }
    public class SwitchWindowRule : IWindowRule
    {
        private ControlCommands _ctrlCommands;
        public string Command => "Switch window";
        public SwitchWindowRule(ControlCommands ctrlCommands) =>
            _ctrlCommands = ctrlCommands;
        public void Invoke() =>
            _ctrlCommands.SwitchWindow();
    }
