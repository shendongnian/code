    Double rDouble;
    if (Double.TryParse(response.Radius, out rDouble))
    {
        var radius = Math.Round(Math.Min(Int16.MaxValue, Math.Max(Int16.MinValue, rDouble)));
        if (radius.ToString() != response.Radius.ToString())
        {
            Logger.Info(String.Format("Response: Received range value {0} is outside the range of SmallInt, thus it is capped to .MaxValue, response.Radius));
        }
        response.Radius = radius.ToString();
    }
    else
    {
        Logger.Info("Response: Range " + response.Radius + " is not a valid number");
    }
