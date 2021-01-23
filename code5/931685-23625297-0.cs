        public void Process(ProcessMessageArgs args)
        {
            var field = args.Fields.GetEntryByName("myFieldName");
            if (field == null)
            {
                return;
            }
            var selection = field.Value;
            // TODO: select the right e-mail according to selection's value
            var email = "the@mail.com";
            // Append the email
            if (args.To.Length != 0)
            {
                args.To.Append(",");
            }
            args.To.Append(email);
        }
