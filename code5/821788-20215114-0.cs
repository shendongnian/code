    private void TypeSelectionChangeCommitted(object sender, EventArgs e)
    {
        if (!ChangeMade)
        {
           //#1 Some Code
        }
        else
        {
            DialogResult dialogResult =
            MessageBox.Show("Are you sure you want to change the manifacturer?" +
                            "\n    All the changes you have done will be lost.",
            "Warning", MessageBoxButtons.YesNo);
        
            if (dialogResult == DialogResult.Yes)
            {
              //same code as #1                
            }
            else
            {
               //Here must be the code that returns the previous 
               //item without selecting it.
            }
        }
    }
