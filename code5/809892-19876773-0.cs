            if (t[i] == '{')
            {
                startIndex = i + 1;   // Start one character beyond {
                break;
            }
            // ...
            if (t[i] == '}')
            {
                stopIndex = i - 1;    // Stop one character prior to }
                break;
            }
