    namespace MyProject
    {
        public class OracleDriverExtended : OracleDataClientDriver
        {
            public override void AdjustCommand(System.Data.IDbCommand command)
            {
                OracleCommand cmd = command as OracleCommand;
                if (cmd != null)
                    cmd.InitialLONGFetchSize = -1;
            }
        }
    }
