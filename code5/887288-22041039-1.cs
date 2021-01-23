       private void GetCommands()
        {
            String[] arrCommands = Environment.GetCommandLineArgs();
            foreach (String command in arrCommands)
            {
                MessageBox.Show(command); // just for debugging purpose / if you'd like to see all parameters
                // get the excel-file-name and open it...
            }
        }
