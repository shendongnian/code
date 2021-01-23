    if (percentage < 0 || percentage > 100) // Guard statement
    {
        if (percentage >= 40)
        {
            if (percentage >= 80)
            {
                // Case (80% to 100%)
                //break;
            }
            else
            {
                if (percentage >= 70)
                {
                    // Case (70% to 79%)
                    //break;
                }
                else
                {
                    // Case (40% to 69%)
                    //break;
                }
            }
        }
        else
        {
            if (percentage >= 20)
            {
                // Case (20% to 39%)
                //break;
            }
            else
            {
                // Case (0% to 19%)
                //break;
            }
        }
    }
    else
    {
        // Default code goes here
        //break;
    }
