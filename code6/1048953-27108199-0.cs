    var patientResults12 = patientResults.Select(x =>
    {
        var patientMeasurementResult = new PatientMeasurementResult()
        {
            MeasurementTime = x.Key.MeasurementTime,
            Model = x.Key.Model,
            DeviceId = x.Key.DeviceId,
        };
        var result = x.FirstOrDefault();
        if (result != null)
        {
            patientMeasurementResult.PatientId = result.PatientId;
            patientMeasurementResult.PatientName = result.PatientName;
        }
        return patientMeasurementResult;
    });
