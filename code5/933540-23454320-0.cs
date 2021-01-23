      public TemperaturePresenter()
      {
         _view = new MainView(this);
         serverDoc = new XmlDocument();
         responseDoc = new XmlDocument();
         LoadTemperatures();
      }
      public void LoadTemperatures()
      {
            ThreadPool.QueueUserWorkItem(
            delegate
            {
                .. a lot of things to check here ...
            }
      }
      ,,,,,
      public void btnUpdate_Click(object sender, EventArgs e)
      {            
         _parent.LoadTemperatures();
      }
