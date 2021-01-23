    int[] num = { 1, 1, 1, 3, 3, 4, 5, 6, 7, 0 };
    int[] count = new int[10];
    //Loop through 0-9 and count the occurances
    for (int x = 0; x < 10; x++){
        for (int y = 0; y < num.Length; y++){
            if (num[y] == x)
                count[x]++;
        }
    }
    //For displaying output only            
    for (int x = 0; x < 10; x++)
        Console.WriteLine("Number " + x + " appears " + count[x] + " times");
