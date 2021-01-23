    // This version of FindCaptureDevice is provide for education only.
    // A second version using the DsDevice helper class is define later.
    public IBaseFilter FindCaptureDevice()
    {
      // ...
      // Create the system device enumerator
      ICreateDevEnum devEnum = (ICreateDevEnum) new CreateDevEnum();
      // Create an enumerator for the video capture devices
      hr = devEnum.CreateClassEnumerator(FilterCategory.VideoInputDevice, out classEnum, 0);
      DsError.ThrowExceptionForHR(hr);
      // The device enumerator is no more needed
      Marshal.ReleaseComObject(devEnum);
      // If there are no enumerators for the requested type, then 
      // CreateClassEnumerator will succeed, but classEnum will be NULL.
      if (classEnum == null)
      {
        throw new ApplicationException("No video capture device was detected.\r\n\r\n" +
                                       "This sample requires a video capture device, such as a USB WebCam,\r\n" +
                                       "to be installed and working properly.  The sample will now close.");
      }
