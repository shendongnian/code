            //If the strings are different lengths, they are not
            //permutations.
            if (myString1.Length != myString2.Length) return false;
            //Create an array to count the number of each specific
            //character in the strings.
            int[] characterCount = new int[256];
            int charIndex;
            //Populate the array with default value 0.
            for (int index = 0; index < 256; index++)
            {
                characterCount[index] = 0;
            }
            //Count the number of each character in the first
            //string. Add the count to the array.
            foreach (char myChar in myString1.ToCharArray())
            {
                charIndex = (int)myChar;
                characterCount[charIndex]++;
            }
            //Count the number of each character in the second
            //string. Subtract the count from the array.
            foreach (char myChar in myString2.ToCharArray())
            {
                charIndex = (int)myChar;
                characterCount[charIndex]--;
            }
            //If the strings are permutations, then each character
            //would be added to our character count array and then
            //subtracted. If all values in this array are not 0
            //then the strings are not permutations of each other.
            for (int index = 0; index < 256; index++)
            {
                if (characterCount[index] != 0) return false;
            }
            //The strings are permutations of each other.
            return true;
        }
    }
}
