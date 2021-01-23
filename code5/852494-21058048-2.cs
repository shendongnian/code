        private static long _isKeyPressed;
        private static void Main()
        {
            // Create a new Thread and Start it. 
            new Thread(() =>
            {
                // Variable for blinking periods after 'exit'
                const string blinkExit = ". . .";
                
                // Displays a message to press any key to exit in the console
                Console.Write("\n\nPress any key to exit"); 
                
                // Run until no keys are pressed.
                while (Interlocked.Read(ref _isKeyPressed) == 0)
                {
                    WriteBlinkingText(blinkExit, 500, true);
                    WriteBlinkingText(blinkExit, 500, false);
                }
            }).Start();
            Console.ReadKey();
            // Once a key has been pressed, increment the value of _isKeyPressed to 1.
            // This will indicate to the thread running above that it should exit it's loop.
            // as _isKeyPressed is no longer equal to 0.
            Interlocked.Increment(ref _isKeyPressed);
        }
        private static void WriteBlinkingText(string text, int delay, bool visible)
        {
            if (visible) Console.Write(text);
            else
            {
                for (int i = 0; i < text.Length; i++)
                {
                    Console.Write(" ");
                }
            }
            Console.CursorLeft -= text.Length;
            Thread.Sleep(delay);
        }
