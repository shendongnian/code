        private class AClass
        {
            public int Value { get; set; }
            public static AClass operator +(AClass a, AClass b)
            {
                return new AClass
                {
                    Value = (a != null ? a.Value : 0) + (b != null ? b.Value : 0)
                };
            }
        }
