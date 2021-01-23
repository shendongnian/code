        // i made a seperate class of Command because it is easy to expand without getting monsterclasse
        public class Command
        {
            private CommandEnum cmd;
            public Command(CommandEnum cmd)
            {
                this.cmd = cmd;
            }
            
            public void Execute(ref NetworkStream stream)
            {
                switch(cmd)
                {
                    //insert commands like stream.write(bytesToSend, 0, bytesToSend.Length);
                    default:
                    break;
                }
            }
        }
