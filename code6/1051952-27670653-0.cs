    public class EdgeDetector
    {
      public delegate void OnRisingEdgeDetected(uint currentValue, uint linesThatAsserted);
      private bool m_shouldPoll;
      private void PollForRisingEdge(PCI_7250 device, OnRisingEdgeDetected onRisingEdgeDetected)
      {
        while (m_shouldPoll)
        {
          // Optional: sleep to avoid consuming CPU
          
          uint newPortValue = device.ReadAllDigitalLines();
          uint changedLines = m_currentPortValue ^ newPortValue;
          uint risingEdges = newPortValue & changedLines;
          m_currentPortValue = newPortValue;
          
          if (risingEdges != 0)
          {
            onRisingEdgeDetected(currentValue: newPortValue,
                                 linesThatAsserted: risingEdges);
          }
      }
      public void Start(PCI_7250 device, OnRisingEdgeDetected onRisingEdgeDetected)
      {
          m_shouldPoll = true;
          PollForRisingEdge(device, onRisingEdgeDetected);
      }
      public void Stop()
      {
          m_shouldPoll = false;
      }
    }
