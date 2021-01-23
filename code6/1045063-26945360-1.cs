        [Fact]
        public void MaxMessageSize()
        {
            var sender = CreateClient();
            var reciver = CreateClient();
            for (int i = 1; i < 255; i++)
            {
                var size = i*1024;
                var buffer = new byte[size];
                random.NextBytes(buffer);
                 BrokeredMessage msg =
                   new BrokeredMessage(buffer);
                msg.Properties["size"] = size;
                sender.Send(msg);
                var message  = reciver.Receive();
                Assert.NotNull(message);
                Assert.Equal(message.Properties["size"], size);
                var bufferReceived = message.GetBody<byte[]>();
                Assert.Equal(buffer, bufferReceived);
                message.Complete();
            }
        }
