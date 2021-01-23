    private void Register(String assemblyName)
      {
          Publish publish = new Publish();
          publish.GacInstall(assemblyName);
      }
