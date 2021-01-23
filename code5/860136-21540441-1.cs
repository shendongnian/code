    public static void Terras(int t) {
        Console.Write("Terras generated:");
        Console.Write(" " + t);
        while (t > 1) {
            int t_previous = t;
            if (t_previous % 2 == 0) {
                t = t_previous / 2;
            } else {
                t = (3 * t_previous + 1) / 2;
            }
            Console.Write(", " + t);
        }
        Console.WriteLine("");
    }
