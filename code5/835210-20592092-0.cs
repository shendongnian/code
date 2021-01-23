    using (ServiceHost Host = new ServiceHost(
        typeof(ModelDataServer),
        new Uri[]{
          new Uri("http://localhost:8000")
        }))
        {
            Host.AddServiceEndpoint(typeof(IModelData),
              new BasicHttpBinding(),
              "ModelData");
            Host.Open();
        }
