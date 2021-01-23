			Console.WriteLine("Enter a 5 digit number: ");
			var sInput = Console.ReadLine(); // Reads all digits at once
            // Check whether the input is a valid number
            int nTest;
            if (!int.TryParse(sInput, out nTest))
            {
                 // invalid input: do something specific here (return, alert user, ...)
            }
            //-- Digits extraction starts here
			var acDigits = sInput.ToCharArray(); // Stores all the digits separately
			var anDigits = new int[acDigits.Length]; // Allocates the target array (matrix of int)
            // for each digit within the source text
			for (var ixDigit = 0; ixDigit < acDigits.Length; ixDigit++)
			{
                // Take the digit char, subtracts '0', stores the value
				anDigits[ixDigit] = acDigits[ixDigit] - '0';
			}
            //-- Digits extraction ends here
            // output
			Console.WriteLine(string.Format("The number is {0} digits long", anDigits.Length));
			// for each stored digit
			for (int ixDigit = 0; ixDigit < anDigits.Length; ixDigit++)
			{
				Console.Write("|" + anDigits[ixDigit].ToString());
			}
			Console.WriteLine("|");
