    var bcd = new ManagementClass(@"root\WMI", "BcdStore", null);
    var openStoreParams = bcd.GetMethodParameters("OpenStore");
    openStoreParams["File"] = "";
    var openStoreResult = bcd.InvokeMethod("OpenStore", openStoreParams, null);
    var openedStore = (ManagementObject)typeof(ManagementBaseObject)
        .GetMethod("GetBaseObject", BindingFlags.Static | BindingFlags.NonPublic)
        .Invoke(
            null,
            new object[]
            {
                typeof(ManagementBaseObject)
                    .GetField("_wbemObject", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(openStoreResult["Store"]),
                bcd.Scope
            }
        );
    var enumObjectsParams = openedStore.GetMethodParameters("EnumerateObjects");
    enumObjectsParams["Type"] = 0;
    var enumObjectsResult = openedStore.InvokeMethod("EnumerateObjects", enumObjectsParams, null);
    var enumObjects = (ManagementBaseObject[])enumObjectsResult["Objects"];
    foreach (var enumObject in enumObjects)
    {
        // Do something
    }
