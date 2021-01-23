                    foreach (JsonValue characteristicValue in itemObject["Characteristics"].GetArray()){
                    JsonObject characteristicObject = characteristicValue.GetObject();
                    ItemCharacteristic characteristic = new ItemCharacteristic(characteristicObject[""].GetString(),
                                                                                                    characteristicObject[""].GetString())
                }
