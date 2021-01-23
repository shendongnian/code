    try
    {
        Assembly assembly = Assembly.LoadFile(Application.StartupPath + "/MyLists.dll");
        System.Resources.ResourceManager resourcemanager = new System.Resources.ResourceManager("ClassLibrary1.Properties.Resources", assembly);
    
        string[] strArrays15 = resourcemanager.GetString("JobList").Split('\n');
    
        for (int row = 0; row < strArrays15.Length; row++)
        {
            string[] columns = strArrays15[row].Split('\t')
            comboBox1.Items.Add(columns[1]);
        }
        return;
    }
    catch (Exception ex )
    {
        MessageBox.Show(ex.ToString());
    }
