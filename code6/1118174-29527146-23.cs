    public class TopTestBuilder
    {
        public Top BuildDefaultTestTop()
        {
            var top = new Top
            {
                Middle = new Middle
                {
                    Freds = new[]
                    {
                        new Fred {Name = "Fred20"},
                        new Fred {Name = "Fred21"}
                    }
                },
                Freds = new[]
                {
                    new Fred {Name = "Fred10"},
                    new Fred {Name = "Fred11"}
                }
            };
            return top;
        }
    }
