        class TestInfo
        {
            static char[] delimiters = new char[] { ',' };
            static int mRequiredCount = -1;
            public string TestID { get; private set; }
            public int Variable1 { get; private set; }
            public float Variable2 { get; private set; }
            //......other variables that are required to be specified for the test
            public TestInfo(string lineFromCSVfile)
            {
                string[] segments = lineFromCSVfile.Split(delimiters);
                if(mRequiredCount < 0)
                    mRequiredCount = this.GetType().GetProperties().Length;
                if (segments.Length < mRequiredCount)
                    throw new Exception(string.Format("Cannot extract required test data from CSV line {0}", lineFromCSVfile));
                else
                {// NB! exception InvalidStringFormat can happen below during parsing
                    TestID = segments[0].Trim();
                    Variable1 = int.Parse(segments[1].Trim());
                    Variable2 = float.Parse(segments[2].Trim());
                    //........... parse other variables here ............
                }
            }
        }
