    private void takeAction(string keyData, string locator, string action, string searchfor)
            {
                switch (keyData)
                {
                    case "Origin":
                        if (action == "Input")
                        {
                            origin_input(locator, searchfor);
                        }
    
                        break;
