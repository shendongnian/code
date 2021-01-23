    public String RemoveChars(String message)
            {
                // The pattern for an expression
                String charPattern = @"[A-Z]{3}-\d{4}-\d{4}";
                // Create a regex object with the pattern
                message = Regex.Match(message, charPattern).Value;
                // Return the message without unwanted chars
                return message;
            }
