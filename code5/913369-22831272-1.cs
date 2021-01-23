	Task modelFactoryTask = GetNewModel(...);
	await Task.WhenAll(
	          modelFactoryTask ,
	          InitialCameras(...),
	          GetMonitoredWaysListAndPushViewData(mainRoadID, segmentID, cityid));
	model = modelFactoryTask.Result;
