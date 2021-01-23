            if (!Regex.IsMatch(this.MyTextBox.Text, @"[A-C][0-9]{4}"))
            {
                SystemManager.ShowMessageBox("Please enter the characters followed by the numbers for the product code. \nExample: A1001", "Information", 2);
            }
      
