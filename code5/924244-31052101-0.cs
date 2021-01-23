     UsbDeviceConnection.ControlTransfer((UsbAddressing)64, 0, 0, 0, null, 0, 0);// reset  mConnection.controlTransfer(0×40, 0, 1, 0, null, 0, 0);//clear Rx
    UsbDeviceConnection.ControlTransfer((UsbAddressing)64, 0, 1, 0, null, 0, 0);// clear Rx
    UsbDeviceConnection.ControlTransfer((UsbAddressing)64, 0, 2, 0, null, 0, 0);// clear Tx
    UsbDeviceConnection.ControlTransfer((UsbAddressing)64, 3, 26, 0, null, 0, 0);// baudrate  57600 115200-0x001A-26, 9600-0x4138-16696, 19200-0x809C-32924, 230040-0x000D-13
    UsbDeviceConnection.ControlTransfer((UsbAddressing)64, 2, 0, 0, null, 0, 0);// flow  control none                                                            
    UsbDeviceConnection.ControlTransfer((UsbAddressing)64, 4, 8, 0, null, 0, 0);// data bit  8, parity  none,  stop bit 1, tx off
