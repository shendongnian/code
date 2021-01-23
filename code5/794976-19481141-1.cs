    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    
    public class fun2013
    {
        public static void Main()
        {
            Console.WriteLine("fun 2013");
            string userName = "";
            do
            {
                Console.Write("LOGIN//: ");
                userName = Console.ReadLine();
            }
            while (userName != "Max");
            Console.Write("Hello " + userName + ", enter your key: ");
    
            // Get a user-input key and make sure it has at least one usable character.
            // Allow only characters [A-Za-z].
            string viginereKey;
            do
            {
                viginereKey = Console.ReadLine();
                // remove everything which is not acceptable
                viginereKey = Regex.Replace(viginereKey, "[^A-Za-z]", "");
                if (viginereKey.Length == 0)
                {
                    Console.Write("Please enter some letters (A-Z) for the key: ");
                }
            }
            while (viginereKey.Length == 0);
    
            // no need to create a new variable for the lowercase string
            viginereKey = viginereKey.ToLower();
            // "\n" in a string writes a new line
            Console.WriteLine("Changing CASE...\n" + viginereKey);
    
            int keyLength = viginereKey.Length;
    
            Console.WriteLine("Enter your message:");
            string message = Console.ReadLine();
            message = message.ToLower();
            int messageLength = message.Length;
    
            StringBuilder cipherText = new StringBuilder();
    
            // first and last characters to encipher
            const int firstChar = (int)'a';
            const int lastChar = (int)'z';
            const int alphabetLength = lastChar - firstChar + 1;
    
            int keyIndex = 0;
    
            for (int i = 0; i < messageLength; i++)
            {
                int thisChar = (int)message[i];
    
                // only encipher the character if it is in the acceptable range
                if (thisChar >= firstChar && thisChar <= lastChar)
                {
                    int offset = (int)viginereKey[keyIndex] - firstChar;
                    char newChar = (char)(((thisChar - firstChar + offset) % alphabetLength) + firstChar);
                    cipherText.Append(newChar);
    
                    // increment the keyIndex, modulo the length of the key
                    keyIndex = (keyIndex + 1) % keyLength;
                }
            }
    
            Console.WriteLine();
            Console.WriteLine(cipherText);
    
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine(); // Exit program
        }
    }
