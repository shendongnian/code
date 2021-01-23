        bool Validate()
        {
            if (!string.IsNullOrWhiteSpace(TextBox1.Text) && !string.IsNullOrWhiteSpace(TextBox2.Text)) // For textboxes that need validation
            {
                return true;
            }
            return false;
        }
