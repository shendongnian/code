    Task.Run(() =>
            {
                        try
                        {
                            if (ConfigurationsManager.Instance.Configurations.Camera == CameraTypes.Nikon)
                                _cameraService = new DslrCameraService(true);
                            else if (ConfigurationsManager.Instance.Configurations.Camera == CameraTypes.CanonEOS1200)
                                _cameraService = new CanonCameraService(true);
                            else if (ConfigurationsManager.Instance.Configurations.Camera == CameraTypes.Multiple)
                                _cameraService = new MultipleCameraService(true);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                  
                }, TaskScheduler.FromCurrentSynchronizationContext())
 
