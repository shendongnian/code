    //added declaration and initialization
    private ColorSpacePoint[] m_pColorSpacePoints;
    //in awake method
    m_pColorSpacePoints = new ColorSpacePoint[pDepthBuffer.Length];
    //accesor to the colorspacepoints
    public ColorSpacePoint[] GetColorSpacePointBuffer()
    {
      return m_pColorSpacePoints;
    }
    //the new process frame method
    void ProcessFrame()
    {
      var pDepthData = GCHandle.Alloc(pDepthBuffer, GCHandleType.Pinned);
      var pDepthCoordinatesData = GCHandle.Alloc(m_pDepthCoordinates, GCHandleType.Pinned);
      var pColorData = GCHandle.Alloc(m_pColorSpacePoints, GCHandleType.Pinned);
      m_pCoordinateMapper.MapColorFrameToDepthSpaceUsingIntPtr(
        pDepthData.AddrOfPinnedObject(), 
        (uint)pDepthBuffer.Length * sizeof(ushort),
        pDepthCoordinatesData.AddrOfPinnedObject(), 
        (uint)m_pDepthCoordinates.Length);
      m_pCoordinateMapper.MapDepthFrameToColorSpaceUsingIntPtr(
        pDepthData.AddrOfPinnedObject(),
        pDepthBuffer.Length * sizeof(ushort),
        pColorData.AddrOfPinnedObject(),
        (uint)m_pColorSpacePoints.Length);
      pColorData.Free();
      pDepthCoordinatesData.Free();
      pDepthData.Free();
      m_pColorRGBX.LoadRawTextureData(pColorBuffer);
      m_pColorRGBX.Apply ();
    }
