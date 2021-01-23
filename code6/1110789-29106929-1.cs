    for (int i = 1; i <= 100; i++)
    {
        var buttonName = string.Format("button{0}", i);
        var foundControl = Controls.Find(buttonName, true).FirstOrDefault();
        if (foundControl != null)
        {
            foundControl.BackColor = Color.Red;
            
            // If you need to set button-specific properties (i.e. properties
            // that are not common to all controls), then cast it to a button:
            var buttonControl = foundControl as Button;
            if (buttonControl != null)
            {
                buttonControl.UseVisualStyleBackColor = true;
            }
        }
    }
