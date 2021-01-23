        if (ButtonText == "MS")
        {
            MemoryStore = Decimal.Parse(txtDisplay.Text);
            return;
        }
        if (ButtonText == "M-")
        {
            // Memory subtract
            MemoryStore -= EndResult;
            txtDisplay.Text = MemoryStore.ToString();
            return;
        }
        if (ButtonText == "M+")
        {
            // Memory add 
            MemoryStore += EndResult;
            txtDisplay.Text = MemoryStore.ToString();
            return;
        }
