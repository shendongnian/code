    using (var key = Registry.CurrentUser.OpenSubKey(@"Software\TDCredentials"))
    {
        if (key == null)
        {
            // Couldn't open the key, now what?
            // You need to make a decision here.
            // If you read the documentation for CreateSubKey,
            // you'll see that it can *also* return null, so don't rely on it.
        }
        else
        {
            // OK, opened the key, and the using statement will close it.
            // Now we can try reading values. See the next part of the answer.
        }
    }
