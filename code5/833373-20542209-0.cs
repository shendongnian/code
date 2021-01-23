    private void CreateForm<T>(string FormName, FormStartPosition FSP, FormWindowState FWS) where T : Form
    {
      lock(obj)
      {
        if(InstanceDictionary.ContainsKey(FormName))
           InstanceDictionary[FormName].Show();
        try
        {
            var NewInstance = (T)Activator.CreateInstance(typeof(T), FormName);
            InstanceDictionary.Add(FormName);
            ((T)NewInstance).StartPosition = FSP;
            ((T)NewInstance).WindowState = FWS;
            ((T)NewInstance).MdiParent = this;
            ((T)NewInstance).Show();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message.ToString());
            MainFunctionality.ErrorRecorder(ex);
        }
      }
    }
