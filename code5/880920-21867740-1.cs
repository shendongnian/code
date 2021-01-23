    protected async Task Speak(string message)
    {
        int previousLetters = 0;
        double letters = 0.0;
        while (letters < message.Length)
        {
            double ellapsedTime = await Game.Frame;
            await Task.Yield();
            Console.WriteLine("Speak on thread:  " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            letters += ellapsedTime * LETTERS_PER_MILLISECOND;
            if (letters - previousLetters > 1.0)
            {
                System.Console.Out.WriteLine("[" + this.id.ToString() + "]" + message.Substring(0, (int)Math.Floor(Math.Min(letters, message.Length))));
                previousLetters = (int)Math.Floor(letters);
            }
        }
    }
