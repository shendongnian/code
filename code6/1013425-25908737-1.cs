        static void Example()
        {
            var verbs = new string[] { null, null };
            if (verbs.Count() > 1)
            {
                mutateArray(ref verbs); //this would run another thread --> race condition
                throw new ArgumentException();
            }
        }
        private static void mutateArray(ref string[] verbs)
        {
            verbs = new string[] { null };
        }
