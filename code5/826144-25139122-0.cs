    try
    {
        EDSDK.EdsSendCommand(cameraDev, EDSDK.CameraCommand_PressShutterButton, 1); // Half
        EDSDK.EdsSendCommand(cameraDev, EDSDK.CameraCommand_PressShutterButton, 3); // Completely
    }
    finally
    {
        EDSDK.EdsSendCommand(cameraDev, EDSDK.CameraCommand_PressShutterButton, 0); // Off
    }
    
