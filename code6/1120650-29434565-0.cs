    try
    {
        Mileage = (int)MyCar.GetType().GetProperty("Mileage").GetValue(MyCar, null);
    }
    catch (Exception e)
    {
        // in this case, the instance has no property named "Mileage"
    }
