     public void RunStarted(string name, int testCount)
     {
         try
         {
             _instanceId = Environment.GetEnvironmentVariable("InstanceId");
             _buildId = Environment.GetEnvironmentVariable("BuildId");
             _browser = Environment.GetEnvironmentVariable("BrowserToTest");
             _template = Environment.GetEnvironmentVariable("TemplateToTest");
         }
         catch { }
     }
     public void TestFinished(TestResult result)
     {
         if (result.ResultState == ResultState.Ignored)
         {
             return;
         }
         var r = new TestingWorkerData
         {
             BuildId = _buildId,
             InstanceId = _instanceId,
             TestName = result.FullName,
             Success = result.IsSuccess,
             TimeTaken = result.Time.ToString(CultureInfo.InvariantCulture),
             Message = result.Message,
             StackTrace = result.StackTrace,
             Browser = _browser,
             Template = _template
         };         
         File.AppendAllLines(@"z:\\results.txt", new[] {JsonConvert.SerializeObject(r)});
     }
     public class TestingWorkerData
     {
         public string TestName { get; set; }
         public bool Success { get; set; }
         public string TimeTaken { get; set; }
         public string Message { get; set; }
         public string StackTrace { get; set; }
         public string InstanceId { get; set; }
         public string Browser { get; set; }
         public string Template { get; set; }
         public string BuildId { get; set; }
     }
