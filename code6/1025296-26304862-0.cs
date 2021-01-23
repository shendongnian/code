    public static class MyTaskComboBoxPopulater()
    {
        public static void LoadTasksToCombobox(ComboBox comboBox)
        {
            try
                {
                    StreamReader task = new StreamReader(dataFolder + TasksFile);
                    string tasks = task.ReadLine();
                    while (tasks != null)
                    {
                        comboBox.Items.Add(tasks);
                        tasks = task.ReadLine();
                    }    
                }
            catch
            {
            }
        }
    }
    public Form MainForm()
    {
        public static void TaskPopulate()
        {
            MyTaskComboBoxPopulater.LoadTasksToCombobox(cbTask);
        }
    }
