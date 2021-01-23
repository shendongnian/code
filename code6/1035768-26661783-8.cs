    public static class ConsoleHelper
    {
        /// <summary>
        /// Gets an integer from the user
        /// </summary>
        /// <param name="prompt">A prompt to display to the user. Can be null.</param>
        /// <param name="errorMessage">An error message to display if the user enters an invalid integer. Can be null</param>
        /// <param name="intValidator">A function to run which will validate the integer. The integer
        /// will be passed to it, and it should return true if the integer is valid. Can be null</param>
        /// <returns>The integer entered by the user</returns>
        public static int GetIntFromUser(string prompt, string errorMessage, Func<int, bool> intValidator)
        {
            int intEntered;
            while (true)
            {
                if (prompt != null) Console.Write(prompt);
                var input = Console.ReadLine();
                if (int.TryParse(input, out intEntered))
                {
                    if (intValidator == null || intValidator(intEntered))
                    {
                        break;
                    }
                }
                if (errorMessage != null) Console.WriteLine(errorMessage);
            }
            return intEntered;
        }
    }
	
