    static void Main(string[] args) {
        Console.WriteLine(AreWeInTrouble(true, true));   // In trouble
        Console.WriteLine(AreWeInTrouble(false, false)); // In trouble
        Console.WriteLine(AreWeInTrouble(true, false));  // Not in trouble
        Console.ReadLine(true);
    }
    static bool AreWeInTrouble(bool aSmile, bool bSmile) {
        // If aSmile matches bSmile then we are in trouble.
        return aSmile == bSmile;
    }
