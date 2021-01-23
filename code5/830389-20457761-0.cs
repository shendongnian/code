    string Query = "UPDATE database.taxi SET PickupLocation=@PickupLocation, PickupArea=@PickupArea, PickupTime=@PickupTime, DestinationLocation=@DestinationLocation,
                    DestinationArea=@DestinationArea, Name=@Name, Address@Address, Tour=@Tour, VehicleRegistration=@VehicleRegistration";
    MySqlConnection conDataBase = new MySqlConnection(constring);
    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
    cmdDataBase.Parameters.AddWithValue("@PickupLocation", txtPickupLocation.Text);
    cmdDataBase.Parameters.AddWithValue("@PickupArea", comboBxPickupArea.Text);
    ....
    ....
    cmdDataBase.ExecuteNonQuery();
