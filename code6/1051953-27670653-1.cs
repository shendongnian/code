    private void Initialize()
    {
      m_dev = DASK.Register_Card(DASK.PCI_7250, 0);
      m_mainThreadScheduler = TaskScheduler.FromCurrentSynchronizationContext();
    }
    private void StartEdgeDetection()
    {
      m_edgeDetectionTask = Task.Factory.StartNew( () =>
        {
          m_edgeDetector.Start(device: m_dev, onRisingEdgeDetected: RescheduleOnMainThread);
        });
    }
    private RescheduleOnMainThread(uint currentValue, uint linesThatAsserted)
    {
      m_onEdgeDetectionTask = Task.Factory.StartNew(
        action: () =>
          {
            MessageBox.Show(currentValue);
          },
        cancellationToken: null,
        creationOptions: TaskCreationOptions.None,
        scheduler: m_mainThreadScheduler);
    }
    private void CleanUp()
    {
      m_edgeDetector.Stop();
      m_edgeDetectionTask.Wait();
      m_onEdgeDetectionTask.Wait();
    }
    public void Form1_Load(object sender, EventArgs e)
    {
      Initialize();
      StartEdgeDetection();
    }
    public void Form1_Closed(object sender, EventArgs e)
    {
      CleanUp();
    }
