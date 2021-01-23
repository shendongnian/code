    private static bool? IsConsole = null;
    public static void Output(string message)
    {
        if (IsConsole == null)
        {
            int width;
            try
            {
                width = Console.WindowWidth;
            }
            catch
            {
                width = 0;
            }
            IsConsole = (width > 0);
        }
        
        if (IsConsole.Value == true)
        {
            // process Console input and output
        }
        else
        {
            // process Windows input and output
        }
    }
