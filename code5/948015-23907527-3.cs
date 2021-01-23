    foreach (var characteristicValue in itemObject["Characteristics"].GetArray())
    {
        var characteristicObject = characteristicValue.GetObject();
        var characteristic = new ItemCharacteristic(
                characteristicObject[""].GetString(),
                characteristicObject[""].GetString()
            );
    }
