            int i = 0;
            while (i < 5)
            {
                if (((Player)GameDB[currentEntryShown]).csNumber[i] == 0)
                {
                    int tabsLeft = tabMatches.TabCount;
                    if(tabsLeft > 1)
                    {
                        tabMatches.TabPages.Remove(tabMatches.SelectedTab);
                        tabsLeft--;
                    }
    
                }
                i++;
            }  
