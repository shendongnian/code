    public class LookedUpAddress
        {
            public string Address1 { get; set; }
            //...
    // Deserialise...
    List<LookedUpAddress> addressListStub = serializer.Deserialize<List<LookedUpAddress>>(result);
    // Use it to create the entity
    foreach (LookedUpAddress addr in addressListStub)
                    {
                        addressList.Add(
                            new Address(
                            addr.AddressLine1,
                            //...
