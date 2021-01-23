    public class TestSystem
    {
        public void Run()
        {
            CommandManager cm = new CommandManager();
            cm.FillCommandsList(new Assembly[] { this.GetType().Assembly }, new Assembly[] { this.GetType().Assembly });
            try
            {
                Console.WriteLine("Executing command StartCommand");
                cm.ExecuteCommand(new StartCommand());
                Console.WriteLine("Command executed with success");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception raised.\n{0}", ex.Message);
            }
            try
            {
                Console.WriteLine("Executing command null");
                cm.ExecuteCommand(null);
                Console.WriteLine("Command executed with success");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception raised.\n{0}", ex.Message);
            }
            try
            {
                Console.WriteLine("Executing command OtherCommand");
                cm.ExecuteCommand(new OtherCommand());
                Console.WriteLine("Command executed with success");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception raised.\n{0}", ex.Message);
            }
            try
            {
                Console.WriteLine("Trying to add commands already in the list of commands");
                cm.FillCommandsList(new Assembly[] { this.GetType().Assembly }, new Assembly[] { this.GetType().Assembly });
                Console.WriteLine("Command add with success");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception raised.\n{0}", ex.Message);
            }
        }
    }
