    public class TargetBuilder
    {
        public ICommandBuilder CommandBuilder { get; set; }
    
        public Target CreateTarget()
        {
            var target = new Target();    
            /* Some code to configure target */
    
            var commandBuilder = CommandBuilder ?? target;
            target.AddCommand(commandBuilder.BuildCommand());
    
            return target;
        }
    }
