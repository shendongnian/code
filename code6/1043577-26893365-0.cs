        public void InsertInOrder(int item)
        {
            Link temp = list;
            // check to see if the item goes at the front of the list...
            //   hint : there are 2 conditions where it needs to go in the front.
            if (********* || **********)
            {
                list = new Link(item, list);
            }
            else
            {
                while (temp != null)
                {
                    // you have to look at the next item and see if it's bigger
                    //  which means it goes next.
                    //  if there isn't a next item this item belongs next.
                    if (*********** || // there is no next item
                        ***********) // this item is bigger than the next item
                    {
                        temp.Next = new Link(item, temp.Next);
                        // we are done so set temp to null so we exit the loop
                        temp = null;
                    }
                    else
                    {
                        // move on to the next item
                        temp = temp.Next;
                    }
                }
            }
        }
