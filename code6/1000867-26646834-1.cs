        public static void TestPublicNewProperty()
        {
            var baseClass = new BaseClass() { Id = 31 };
            var derivedClass = new DerivedFromBaseClass { Id = 31 };
            var baseXml = baseClass.GetXml();
            // Xml looks like 
            Debug.Assert(baseXml.Contains("Id")); // No assert
            var derivedXml = derivedClass.GetXml();
            Debug.Assert(!derivedXml.Contains("Id")); // no assert.
        }
