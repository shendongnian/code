    public static unsafe extern CoStatus GetCrashMeasurements(string sChannel,
                                                              string sMeasurements,
                                                              [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.LPTStr)]
                                                              string[] sValues,
                                                              IntPtr hError);
