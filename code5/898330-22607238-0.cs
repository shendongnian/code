    /// <summary>
    /// Create a person from a serial number
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when serial number is outside valid     range</exception>
    /// <param name="serial"></param>
    public Person(int serial)
    {
    if (serial == 0)
        {
        throw new ArgumentException("Serial number cannot be zero");
        }
    }
