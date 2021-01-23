            label1.Text = "Test";
            // this is the simple Task.Factory.StartNew(Action) overload
            Task.Factory.StartNew(() =>
            {
                // do some lengthy processing
                Thread.Sleep(1000);
                // when done, invoke the update on a gui thread
                this.Invoke(new Action(() => label1.Text = "Done"));
            });
