    bool is_wifi_enabled = false;
    Guid adapter_id = new Guid();
    // get the list of connection profiles
    // we need the adpater id for the wifi
    foreach (var item in NetworkInformation.GetConnectionProfiles())
    {
        // check if wifi
        if (item.IsWlanConnectionProfile)
        {
            // tag the adapter
            adapter_id = item.NetworkAdapter.NetworkAdapterId;
        }
    }
    // get all lan adapters (this most likely will be empty if wlan is disabled)
    foreach (var item in NetworkInformation.GetLanIdentifiers())
    {
        if (item.NetworkAdapterId == adapter_id)
        {
            is_wifi_enabled = true;
        }
    }
