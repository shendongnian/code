    class GameBoard
    {
        public static bool IsValid(int width, int height, out List<string> errorMessages)
        {
            // validation logic here, e. g.
            errorMessages = new List<string>();
            if (width < 1) { errorMessages.Add("width must be a positive number");
            return errorMessages.Count == 0;   
        }
    
        public GameBoard(int width, int height)
        {
            var errorMessages;
            var isValid = IsValid(width, height, out errorMessages);
            // fail hard if given invalid input here
            Throw<ArgumentException>.If(
                !isValid, 
                string.Join(", ", errorMessages ?? new List<string>())
            );
            
            this.Width = width;
            this.Height = height;
        }
    }
    
    // in the gui code
    
    // read input
    List<sting> errorMessages;
    while (!IsValid(width, height, out errorMessages))
    {
        // display errorMessages
        // read input
    }
