    private Accelerometer _accelerometer;
    public void Initialize()
    {
        if (_accelerometer != null)
        {
            _accelerometer = Accelerometer.GetDefault();
            _accelerometer.ReadingChanged += _accelerometer_ReadingChanged;
        }
    }
    private void _accelerometer_ReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs args)
    {
        AccelerometerReading reading = _accelerometer.GetCurrentReading();
        Vector3 stateValue = new Vector3();
        stateValue.Y = -1;
        stateValue.X = (float)reading.AccelerationX;
        stateValue.Z = (float)reading.AccelerationY;
        stateValue.Normalize();
        Vector3 currentAccelerometerState = stateValue;
        Vector3 Rotation = Vector3.Zero;
        if (currentAccelerometerState.X != 0)
            marble.speed += new Vector3(currentAccelerometerState.X, 0, 0);
        if (currentAccelerometerState.Z != 0)
            marble.speed += new Vector3(0, 0, -currentAccelerometerState.Z);
        if (marble.speed.Length() > 10)
        {
            marble.speed.Normalize();
            marble.speed *= 10;
        }
    }
