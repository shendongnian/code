    // Remove this line, as it servers no discernible purpose
    //parkingSlot=Convert.ToString(licensePlate);
    int nextAvailableSlot = FindSlot("");
    if (nextAvailableSlot != -1)
    {
        name[nextAvailableSlot] = nameInput;
        // Use the value the user gave for the license plate
        licensePlate[nextAvailableSlot] = licensePlateInput;
    }
