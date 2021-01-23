        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            // TODO: parse error and gets response
            var response = new CompositeType {BoolValue = true, StringValue = "a"};
            fault = Message.CreateMessage(version, "http://tempuri.org/", new MyBodyWriter(response));
        }
