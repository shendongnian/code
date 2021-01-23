            // Create a variables 'container' to store variables
            Variables vars = null;
            // Add variables from the VariableDispenser to the variables 'container'
            Dts.VariableDispenser.GetVariables(ref vars);
            //string filepath;
           // filepath = vars["User::FolderPath"].Value.ToString();
           // vars["User::FileExistsFlg"].Value = File.Exists(filepath);
            vars["User::a1"].Value = 35;
            MessageBox.Show(vars["User::a1"].Value.ToString());
            // Release the locks
            vars.Unlock();
            Dts.TaskResult = (int)ScriptResults.Success;
