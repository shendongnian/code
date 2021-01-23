    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static unsafe void FillRange(ref int[] array) {
        fixed(int* p = &array[0]) {
            for(int i = 0; i < array.Length; ++i) {
                *(p + i) = i;
            }
        }
    }
    static void Main(string[] args) {
        // Example usage:
        int[] availableIndeces = new int[6];
        FillRange(ref availableIndeces);
        // Test if it worked:
        foreach(var availableIndex in availableIndeces) {
            Console.WriteLine(availableIndex);
        }
        Console.ReadKey(true);
    }
