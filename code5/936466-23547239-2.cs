    using Windows.Devices.Bluetooth;
    // look for any paired device
    PeerFinder.AllowBluetooth = true;
    // start looking for BT devices
    PeerFinder.Start();
    PeerFinder.AlternateIdentities["Bluetooth:Paired"] = "";
    // get the list of paired devices
    var peers = await PeerFinder.FindAllPeersAsync();
    var peer = peers.First(p => p.DisplayName.Contains("my_bt_device_name"));
    var bt = await BluetoothDevice.FromHostNameAsync(peer.HostName);
    if (bt.ConnectionStatus == BluetoothConnectionStatus.Connected)
    {
        // My device is connected
    }
