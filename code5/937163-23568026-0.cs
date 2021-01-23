    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using Rally.RestApi;
    using Rally.RestApi.Response;
    
    namespace addTCtoTS
    {
        class Program
        {
            static void Main(string[] args)
            {
                RallyRestApi restApi;
                restApi = new RallyRestApi("user@co.com", "secret", "https://rally1.rallydev.com", "v2.0");
    
                String projectRef = "/project/222"; 
                Request testSetRequest = new Request("TestSet");
                testSetRequest.Project = projectRef;
                testSetRequest.Fetch = new List<string>()
                    {
                        "Name",
    		    "FormattedID",
                        "TestCases"
                    };
    
                testSetRequest.Query = new Query("FormattedID", Query.Operator.Equals, "TS22");
                QueryResult queryTestSetResults = restApi.Query(testSetRequest);
                String tsRef = queryTestSetResults.Results.First()._ref;
                String tsName = queryTestSetResults.Results.First().Name;
                Console.WriteLine(tsName + " "  + tsRef);
                DynamicJsonObject testSet = restApi.GetByReference(tsRef, "FormattedID", "TestCases");
                String testCasesCollectionRef = testSet["TestCases"]._ref;
                Console.WriteLine(testCasesCollectionRef);
    
                ArrayList testCasesList = new ArrayList();
    
                foreach (var ts in queryTestSetResults.Results)
                {
                    Request tcRequest = new Request(ts["TestCases"]);
                    QueryResult queryTestCasesResult = restApi.Query(tcRequest);
                    foreach (var tc in queryTestCasesResult.Results)
                    {
                        var tName = tc["Name"];
                        var tFormattedID = tc["FormattedID"];
                        Console.WriteLine("Test Case: " + tName + " " + tFormattedID);
                        DynamicJsonObject aTC = new DynamicJsonObject();
                        aTC["_ref"] = tc["_ref"];
                        testCasesList.Add(aTC);  //add each test case in the collection to array 'testCasesList'
                    }
                }
                
    	 Console.WriteLine("count of elements in the array before adding a new tc:" + testCasesList.Count);
    
              DynamicJsonObject anotherTC = new DynamicJsonObject();
              anotherTC["_ref"] = "/testcase/123456789";             //any existing test to add to the collection
    
               testCasesList.Add(anotherTC);
    
               Console.WriteLine("count of elements in the array:" + testCasesList.Count);
               testSet["TestCases"] = testCasesList;
               OperationResult updateResult = restApi.Update(tsRef, testSet);
               
            }
        }
    }
