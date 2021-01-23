    DoSomething(new Progress<string>(status => Console.WriteLine(status)))
        .ContinueWith(t =>
            {
                if (t.Exception != null)
                    Console.WriteLine("EXCEPTION: " + t.Exception.InnerException.Message);
                else
                    Console.WriteLine("COMPLETED");
            });
