    string currentValue = "";
                List.ForEach(x =>
                {
                    if (string.IsNullOrEmpty(currentValue))
                    {
                        // Assuming PropA will never be null
                        currentValue = x.PropA;
                        // this is first element
                        return;
                    }
                    if (x.PropA == currentValue)
                    {
                        x.PropA = "";
                    }
                    else
                    {
                        currentValue = x.PropA;
                    }
    
                });
