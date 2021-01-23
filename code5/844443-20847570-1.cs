        void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("Cancelling...");
            cts.Cancel();
            e.Cancel = true;    // Do not terminate immediately!
        }
