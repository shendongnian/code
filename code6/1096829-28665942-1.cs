    nonManagedBuffer = Marshal.AllocHGlobal(inputReportBuffer.Length);
    nonManagedOverlapped = Marshal.AllocHGlobal(Marshal.SizeOf(hidOverlapped));
    Marshal.StructureToPtr(hidOverlapped, nonManagedOverlapped, false);
    // Read the input report buffer
       Debug.WriteLine("usbGenericHidCommunication:readReportFromDevice(): -> Attempting to ReadFile");
    success = Kernel32.ReadFile(
                    deviceInformation.ReadHandle,
                    nonManagedBuffer,
                    inputReportBuffer.Length,
                    ref numberOfBytesRead,
                    nonManagedOverlapped);
                if (!success)
                {
                    // We are now waiting for the FileRead to complete
                    Debug.WriteLine(
                        "usbGenericHidCommunication:readReportFromDevice(): -> ReadFile started, waiting for completion...");
                    // Wait a maximum of 3 seconds for the FileRead to complete
                    var result = Kernel32.WaitForSingleObject(eventObject, 3000);
                    switch (result)
                    {
                            // Has the ReadFile completed successfully?
                        case Constants.WaitObject0:
                            // Get the number of bytes transferred
                            Kernel32.GetOverlappedResult(deviceInformation.ReadHandle, nonManagedOverlapped, ref numberOfBytesRead, false);
                            Debug.WriteLine("usbGenericHidCommunication:readReportFromDevice(): -> ReadFile successful (overlapped) {0} bytes read", numberOfBytesRead);
                            break;
                            // Did the FileRead operation timeout?
                        case Constants.WaitTimeout:
                            // Cancel the ReadFile operation
                            Kernel32.CancelIo(deviceInformation.ReadHandle);
