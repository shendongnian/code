    List<MenuItem> inputDevice = new List<MenuItem>();
    MenuItem myMenuItemInputDevices = new MenuItem("&Input Devices");
    sgFileMenu.MenuItems.Add(myMenuItemInputDevice);
    for (int i = 0; i < DeviceCount; i++)
    {
        inputDeviceMenu.Add(new MenuItem(inputName[i]));
        inputDeviceMenu[i].Click += new System.EventHandler(this.myMenuItemInputDeviceClick);
        myMenuItemInputDevices.MenuItems.Add(inputDeviceMenu[i]);
        myMenuItemInputDevices.Click += new System.EventHandler(this.myMenuItemInputDeviceClick);
    }
