    int open = 0;
    for (int i = 0; i < text.Length; i++)
    {
        switch (text[i])
        {
            case '{':
                open++;
                break;
            case '}':
                if (open > 0)
                {
                    open--; // Matches an opening brace
                }
                else
                {
                    // Whatever you want to do for an unmatched brace
                }
                break;
            default: // Do nothing
                break;
        }
    }
