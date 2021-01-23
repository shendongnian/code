    foreach (JsonValue characteristicValue in itemObject["Characteristics"].GetArray()){
                        JsonObject characteristicObject = characteristicValue.GetObject();
                        
                        var toObject = characteristicObject.GetObject();         
                        var lijst = toObject.ToList();
                       
                        foreach (KeyValuePair<string, IJsonValue> characteristics in lijst)
                        {
                            string productCharacteristic = characteristics.Key.ToString();
                            ItemCharacteristic characteristic = new ItemCharacteristic(productCharacteristic, characteristicObject[productCharacteristic].GetString());
                                                                                   
                            product.Characteristics.Add(characteristic);
                        }
                    }
