    public void addToFleet(String make, String model, String registration, int year, Double costPrice)
    {
        if  (!Fleet.Any(x => x.Registration.ToLower() == registration.ToLower()))
            Fleet.Add(new Car(make, model, registration, year, costPrice));
    }
