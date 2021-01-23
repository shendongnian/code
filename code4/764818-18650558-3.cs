        void exe_Exited(object sender, EventArgs e)
        {
            // If all the procees have been exited
            if (selectedProcesses.Count == 0)
            {
                Environment.Exit(0);
            }
            // Else remove a process from the list
            selectedProcesses.RemoveAt(selectedProcesses.Count - 1) ;
        }
