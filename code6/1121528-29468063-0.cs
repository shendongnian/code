        internal class DefaultAllReadingsDataProvider : DataProvider
             {
                internal override OutputData GetOutputData(Guid userId, int N, int pageNum)
                {
                   IntelliChart iclass = new IntelliChart("test");
                   Response.Write(iclass._chartName);
                }
             }
