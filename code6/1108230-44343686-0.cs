        public partial class YourEntities
        {
            [DbFunction("YourModel.Store", "CalculatedValueSproc")]
            public string CalculatedValueSproc(int? Id)
            {
                throw new NotSupportedException("Direct calls are not supported.");
            }
        }
