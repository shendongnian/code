    private static void Main(string[] args)
    {
        string[] Arguments = new string[] {"111", "222"};
        string[] ParameterSwitches = new string[] {"111", "222"};
        for (int i = 0; i < Arguments.Length; i++)
        {
            foreach (string pSwitch in ParameterSwitches)
            {
                if (pSwitch == Arguments[i])
                {
                    // set breakpoint here to see
                    Arguments[i] = null;
                }
            }
        }
    }
