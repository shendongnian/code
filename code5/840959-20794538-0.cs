    // creates a query object. It is the equivalent of 
    // "SELECT ... FROM ..." as a string. It doesn't actually
    // execute the query.
    EntityQuery<Measurement> query = 
      from p in service.GetMeasurementsQuery() select p;
    
    // sends the query to the server, but the server doesn't
    // return a result in the LoadOperation. The LoadOperation
    // will call you back when it is completed.
    LoadOperation<Measurement> measurement = service.Load(query);
    // when results are available, MeasurementLoaded is called
    measurement.Completed += MeasurementLoaded;
    // WARNING: do not have any code that expects results here.
    // var myMeasurements = service.Measurements;
    public void MeasurementLoaded(object sender, EventArgs eventArgs)
    {
       // you can use service.Measurements now.
       var myMeasurements = service.Measurements;
    }
