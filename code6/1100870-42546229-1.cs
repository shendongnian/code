    var connection = await adapter.ConnectToDevice( peripheral, TimeSpan.FromSeconds( 5 ));
    if(connection.IsSuccessful())
    {
       var gatt = connection.GattServer;
       var value = await gatt.ReadCharacteristicValue( someServiceGuid, someCharacteristicGuid );
       await gatt.WriteCharacteristicValue( someServiceGuid, someCharacteristicGuid, new byte[]{ 1, 2, 3 } );
       // etc...
    }
    else
    {
       Debug.WriteLine( "Error connecting to device. result={0:g}", connection.ConnectionResult );
    }
