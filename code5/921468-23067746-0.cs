     public void AfterTest(TestDetails details)
            {
                switch (TestContext.CurrentContext.Result.Status)
                {
                    case TestStatus.Failed:
                    case TestStatus.Inconclusive:
                        try
                        {
                            (details.Fixture as SeleniumBaseTest).TakeScreenShot();
                        }
                        catch (NullReferenceException)
                        {
                            throw new TypeAccessException("This decorator should only be used with {0}" + typeof(SeleniumBaseTest).Name);
                        }
                        break;
                }
            }
