        if (ButtonText == "MS")
        {
            MemoryStore = Decimal.Parse(txtDisplay.Text);
            return;
        }
       if (ButtonText == "M-")
        {
            // Memory subtract
            MemoryStore -= EndResult;
            return;
        }
