    foreach(var i in items)
    {
        // Fake conditions for the purpose of example
        bool firstCondition = i.Value1 == 17,
            secondCondition = i.Value2 == 37;
        for(int if1 = 0; if1 < 1; if1++)
        {
            for(int if2 = 0; if2 < 1; if2++)
            {
                bool localCondition1 = if1 == 0 ? !firstCondition : firstCondition,
                    localCondition2 = if2 == 0 ? !secondCondition : secondCondition;
                if (localCondition1 && localCondition2)
                {
                    switch (if1 + if2 * 2)
                    {
                    case 0:
                        // if1 == 0, if2 == 0
                        break;
                    case 1:
                        // if1 == 1, if2 == 0
                        break;
                    case 2:
                        // if1 == 0, if2 == 0
                        break;
                    case 3:
                        // if1 == 1, if2 == 1
                        break;
                    }
                }
            }
        }
    }
