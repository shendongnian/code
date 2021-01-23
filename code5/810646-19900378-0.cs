            for (int i = 1; i <= 10; i++)
            {
                Control[] matches = this.Controls.Find("txt_Address" + i.ToString(), true);
                if (matches.Length > 0 && matches[0] is TextBox)
                {
                    TextBox tb = (TextBox)matches[0];
                    // ... do something with "tb" ...
                }
            }
