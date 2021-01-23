            int i = 1;
            Control[] matches = this.Controls.Find("Card" + i.ToString(), true);
            if (matches.Length > 0 && matches[0] is Button)
            {
                Button btn = (Button)matches[0];
                // ... do something with "btn" ...
                btn.PerformClick();
            }
