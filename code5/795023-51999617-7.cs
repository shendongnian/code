	public void ExecuteMeasurement(CancellationToken cancelToken)
	{
		SafeExecute.Invoke(
			() => DUT.ExecuteMeasurement(cancelToken),
			() =>
			{
				Logger.Write(TraceEventType.Verbose, "Save measurement results to database...");
				_Db.SaveChanges();
			},
			() => TraceLog.Write(TraceEventType.Verbose, "Done"));
	}
