        [Given(@"'(.*)' logs in")]
        public static void GivenUserLogsIn(string user)
        {
            if (string.Equals("Bob")
                DoBobScenario();
            else if (string.Equals("Joe")
                DoJoeScenario();
        }
