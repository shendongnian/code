    foreach (var characteristicValue in itemObject["Characteristics"].GetArray())
    {
        var characteristicObject = characteristicValue.GetObject();
        var toObject = characteristicObject.GetObject();         
        var lijst = toObject.ToList();
        foreach (var characteristics in lijst)
        {
            var productCharacteristic = characteristics.Key.ToString();
            ItemCharacteristic characteristic = new ItemCharacteristic(productCharacteristic, characteristicObject[productCharacteristic].GetString());
                                                               
            product.Characteristics.Add(characteristic);
        }
    }
