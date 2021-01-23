        public static void ExitServer()
        {
            if (Server == null)
            {
                return;
            }
            if (!Server.HasExited)
            {
                ActivateProcess(Server.Id);
                SimulateExitInput();
            }
        }
