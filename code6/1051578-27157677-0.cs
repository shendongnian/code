        private static HashSet<string> StateList = new HashSet<string>
            {
                "AL","AK", ...
            };
        protected void stateArrayCheck(Object source, ServerValidateEventArgs args)
        {
            args.IsValid = StateList.Contains(valState.Text);
        }
