    [DllImport("kernel32.dll")]
    public static extern uint GetLastError();
    bool retVal = SetDeviceGammaRamp(hdc, gArray);
    if (retVal == false)
    {
        System.Console.WriteLine(GetLastError());
    }
error code is 87: ERROR_INVALID_PARAMETER
