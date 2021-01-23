    static char[] comments = { '/', '{', '}', ' ', '\t' };
    public static void IsCommentDisabledCodeComment(Class classItem, IfSQRules context)
    {
        // ...
            if (token.Text.Except(comments).Any())
            {
                // something other 
            }
        // ...
    }
