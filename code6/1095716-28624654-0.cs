    bool found = false;
    foreach(ListviewItem originalItem in myOriginalList.Items)
    {
        foreach(ListViewItem copiedItem in myNewList.Items)
        {
             //Check for equality between both items
             if(originalItem.Text == copiedItem.Text)
             {
                  found = true;
                  break;
             }
        }
        //Check if the entry is found
        if(found == false)
        {
             //TRY TO COPY AGAIN
        }
        //Set the bool back
        found = false;
    }
