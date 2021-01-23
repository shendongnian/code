    private void OnCaptured(CaptureResult captureResult)
    {
       if (InvokeRequired)
       {
           Invoke(new System.Action(() => OnCaptured(captureResult)));
           return;
       }
       txtIdentify.Clear();
       // ...
    }
