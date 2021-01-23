        public void DoSomething()
        {
            // Actually a ParameterizedThreadStart, but you don't need to state this explicitly
            //var listenOnSocket = new Thread(new ParameterizedThreadStart(ListenOnSocket));
            var listenOnSocket = new Thread(ListenOnSocket);
            // Pass the label as the ParameterizedThreadStart parameter
            // TestLabel is a label within the form
            listenOnSocket.Start(TestLabel);
        }
        private void ListenOnSocket(object statusLabelObject) // Parameter must be of type Object
        {
            var statusLabel = statusLabelObject as Label;
            if (statusLabel == null)
                throw new ArgumentException(@"Parameter must be of type Label", "statusLabelObject");
            // Changes to controls must be performed on the UI thread.
            BeginInvoke((Action)(() => statusLabel.Text = @"text"));
        }
