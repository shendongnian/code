    public static string Color(short piece)
    {
        string color = String.Empty;
        //Because we are passing in the short array value we don't 
        //need to get it from the array we can just use it eg:
        if(piece == WP)
            color = "White";
        //Your other if statements go here
        return color;
     }
