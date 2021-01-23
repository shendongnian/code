        private class Engine
        {
            public string Text { get; set; }
            public int Id { get; set; }
            [JsonProperty]  // Causes the protected setter to be called on deserialization.
            public Coords[] Outs { get; protected set; }
            public Engine()
            {
                this.Outs = new Coords[3];
                for (int i = 0; i < this.Outs.Length; i++)
                {
                    this.Outs[i] = new Coords();
                }
            }
        }
