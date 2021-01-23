    public int findTestCase(TDAPIOLELib.TDConnection connection, string testCaseName)
    		{
    			TestFactory tstF = connection.TestFactory as TestFactory;
    			TDFilter testCaseFilter = tstF.Filter as TDFilter;
    			testCaseFilter["TS_TEST_NAME"] = testCaseName;
    			List testsList = tstF.NewList(testCaseFilter.Text);
    			if(testsList != null && testsList.Count == 1)
    			{
    				log.log("Test case " +testCaseName+ " was found ");
    				Test tmp =  testsList[0] as Test;
    				return (int)tmp.ID;
    			}
			
			return -1;
		}
