    using namespace Windows.Devices.Bluetooth;
    BluetoothDevice bt = new BluetoothDevice();
    if (bt.ConnectionStatus == BluetoothConnectionStatus.Connected)
    {
        // My device is connected
    }
