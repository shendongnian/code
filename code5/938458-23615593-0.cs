    Assembly assembly = Assembly.LoadFile(Application.StartupPath + "/MyFiles.dll");
    System.Resources.ResourceManager resourcemanager = new System.Resources.ResourceManager("ClassLibrary1.Properties.Resources", assembly);
    if (resourcemanager != null) {
      string jobListString = resourcemanager.GetString("JobsList");
      if (!String.isNullOrEmpty(jobListString))
        comboBox1.Items.AddRange(strArrays15[0].Split('\t'));
      else
        // handle error
    } else
      //handle error
    return;
