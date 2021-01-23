                EventWaitHandle resetEvent = new AutoResetEvent(false);
            client.ExecuteAsync(request, response =>
            {
                callback(response.Content);
                resetEvent.Set();
                return;
            });
            resetEvent.WaitOne();
        }
        private static void callback(string content)
        {
            System.Console.WriteLine(content);
        }
