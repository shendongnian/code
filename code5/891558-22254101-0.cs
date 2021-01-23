    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
    interface FillArrayI
    {
        // Properties
        [DispId(1000)]
        byte[] result_array { set; get; }
    
        [DispId(2000)]
        int fill_result_array();
    }
