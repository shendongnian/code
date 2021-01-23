    [AfterScenario]
    void SaveScreenShot()
    {
     var queryJustRun = ScenarioContext.Current["query"];
     // You could subsequently append queryJustRun to the screenshot filename
     // e.g. String.Format("{0}_{1}.jpg",
     //                    ScenarioContext.Current.ScenarioInfo.Title,
     //                    queryJustRun ); 
    }
