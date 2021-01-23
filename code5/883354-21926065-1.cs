            int content;
            if (Int32.TryParse(lblTotal.Content.ToString(), out content))
            {
                int calculate = content;
                lblTotal.Content = calculate;
            }
