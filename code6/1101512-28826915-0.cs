    public void callBackLiveImage(IntPtr imgPointer)
    {
      try
      {
        byte[] rawData = new byte[102400];
        Marshal.Copy(imgPointer, rawData, 0, 102400);
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.ToString());
      }
    }
