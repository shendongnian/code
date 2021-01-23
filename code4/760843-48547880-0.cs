    public static double ConvertTemperatureUnits(TemperatureUnit toConvert, TemperatureUnit from, double value)
        {
            double convertedValue = 0.0;
            if (toConvert == from)
                return value;
            switch (toConvert)
            {
                case TemperatureUnit.FAHRENHEIT:
                    {
                        switch (from)
                        {
                            case TemperatureUnit.CELSIUS:
                                convertedValue = (value * 9) / 5 + 32;
                                break;
                            case TemperatureUnit.KELVIN:
                                convertedValue = 1.8 * (value - 273.15) + 32;
                                break;
                        }
                    }
                    break;
                case TemperatureUnit.KELVIN:
                    switch (from)
                    {
                        case TemperatureUnit.CELSIUS:
                            convertedValue = value + 273.15;
                            break;
                        case TemperatureUnit.FAHRENHEIT:
                            convertedValue = (value + 459.67) * 5 / 9;
                            break;
                    }
                    break;
                case TemperatureUnit.CELSIUS:
                    switch (from)
                    {
                        case TemperatureUnit.KELVIN:
                            convertedValue = value - 273.15;
                            break;
                        case TemperatureUnit.FAHRENHEIT:
                            convertedValue = (value - 32) * 5 / 9;
                            break;
                    }
                    break;
            }
            return convertedValue;
        }
