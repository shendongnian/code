    //Note: I'm addressing the pages as a 1-based index. 
    //If 0-based is needed, just add -1 to all index values
    bool previousPageIsEllipsis = false;
    for(int i = 1; i <= totalpages; i++)
    {
        if(i == currentpage) {
            //Print current page number
            previousPageIsEllipsis = false;
        }
        else
        {
            if( i == 1
                || i == 2
                || i == currentpage - 2
                || i == currentpage - 1
                || i == currentpage + 1
                || i == currentpage + 2
                || i == totalpages - 1
                || i == totalpages)
            {
                //Print a visible link button
                
                previousPageIsEllipsis = false;
            }
            else
            {
                if(previousPageIsEllipsis)
                {
                    //an ellipsis was already added. Do not add it again. Do nothing.
                    continue;
                }
                else
                {
                    //Print an ellipsis
                    previousPageIsEllipsis = true;
                }
            }
        }
    }
