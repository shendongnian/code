    private static readonly Lazy<Dictionary<byte, Model_B_Event>> map =
        new Lazy<Dictionary<byte, Model_B_Event>>(() =>
            new Dictionary<byte, Model_B_Event>
            {
                { 0, Model_B_Event.SEND_MODEL_ID },
                { 5, Model_B_Event.SEND_RELAY_VOLTAGE },
                { 6, Model_B_Event.SEND_SPARE_STATUS },
            });
    /// <summary>
    /// Convert the first byte of the received data from USB into a Model B event
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    Model_B_Event Get_Event_From_Data(Byte[] data)
    {
        if (map.Value.TryGetValue(data[0], out matching_event))
            return matching_event;
        return Model_B_Event.NO_EVENT;
    }
