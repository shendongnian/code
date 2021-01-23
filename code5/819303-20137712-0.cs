    private static bool Balanced(string input, string openParenthesis, string closedParenthesis , int startIndex)
    {
        try
        {
            if (startIndex < input.Length)
            {
                //Obtain first character
                string firstString = input.Substring(startIndex, 1);
                //Check if it is open parenthesis
                //If it is open parenthesis push it to stack
                //If it is closed parenthesis pop it
                if (firstString == openParenthesis)
                    stack.Push(firstString);
                else if (firstString == closedParenthesis)
                    stack.Pop();
                //In next iteration, chop off first string so that it can iterate recursively through rest of the string
               Balanced(input, openParenthesis, closedParenthesis , startIndex + 1);   //this call makes the function recursive
            }
            if (stack.Count == 0 && !exception)
                isBalanced = true;
        }
        catch (Exception ex)
        {
            exception = true;
        }
        return isBalanced;
    }
