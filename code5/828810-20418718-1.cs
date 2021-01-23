    private List<string> GetAllAvailableResolution(DsDevice vidDev)
    {
       try
       {
         int hr, bitCount = 0;
         IBaseFilter sourceFilter = null;
         var m_FilterGraph2 = new FilterGraph() as IFilterGraph2;
         hr = m_FilterGraph2.AddSourceFilterForMoniker(vidDev.Mon, null, vidDev.Name, out sourceFilter);
         var pRaw2 = DsFindPin.ByCategory(sourceFilter, PinCategory.Capture, 0);
         var AvailableResolutions = new List<string>();
         VideoInfoHeader v = new VideoInfoHeader();
         IEnumMediaTypes mediaTypeEnum;
         hr = pRaw2.EnumMediaTypes(out mediaTypeEnum);
         AMMediaType[] mediaTypes = new AMMediaType[1];
         IntPtr fetched = IntPtr.Zero;
         hr = mediaTypeEnum.Next(1, mediaTypes, fetched);
         while (fetched != null && mediaTypes[0] != null)
         {
           Marshal.PtrToStructure(mediaTypes[0].formatPtr, v);
           if (v.BmiHeader.Size != 0 && v.BmiHeader.BitCount != 0)
           {
             if (v.BmiHeader.BitCount > bitCount)
             {
               AvailableResolutions.Clear();
               bitCount = v.BmiHeader.BitCount;
             }
             AvailableResolutions.Add(v.BmiHeader.Width +"x"+ v.BmiHeader.Height);
           }
           hr = mediaTypeEnum.Next(1, mediaTypes, fetched);
         }
         return AvailableResolutions;
       }
       catch (Exception ex)
       {
         MessageBox.Show(ex.Message);
         return new List<string>();
       }
    }
