        /// <summary>
        /// Returns Error Message Details extracted from TestContext
        /// </summary>
        /// <param name="testContext"></param>
        /// <returns></returns>
        public static string GetErrorMessageFromTestContext(TestContext testContext)
        {
            const BindingFlags privateGetterFlags = System.Reflection.BindingFlags.GetField |
                                                    System.Reflection.BindingFlags.GetProperty |
                                                    System.Reflection.BindingFlags.NonPublic |
                                                    System.Reflection.BindingFlags.Instance |
                                                    System.Reflection.BindingFlags.FlattenHierarchy;
            var m_message = string.Empty; // Returns empty if TestOutcome is not failed
            if (testContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                // Get hold of TestContext.m_currentResult.m_errorInfo.m_message (contains the exception text that was thrown)
                var field = testContext.GetType().GetField("m_currentResult", privateGetterFlags);
                var m_currentResult = field.GetValue(testContext);
                field = m_currentResult.GetType().GetField("m_errorInfo", privateGetterFlags);
                var m_errorInfo = field.GetValue(m_currentResult);
                field = m_errorInfo.GetType().GetField("m_message", privateGetterFlags);
                m_message = field.GetValue(m_errorInfo) as string;
            }
            return m_message;
        }
