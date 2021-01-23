            try
            {
                YourFunction();
            }
            catch (System.Security.SecurityException)
            {
                MessageBox.Show("You do not have permission to perform this action.", "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            ...
