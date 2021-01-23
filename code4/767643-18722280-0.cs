        DateTime dt;
        int days = 0;
        bool success = Int32.TryParse(maskedTextBox2.Text, out days);
        success |= DateTime.TryParse(zpocdnu.Text, out dt);
        if (success)
            maskedTextBox2.Text = dt.AddDays(days).ToString();
