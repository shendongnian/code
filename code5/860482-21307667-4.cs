    public override void Configure(Funq.Container container)
    {
        container.Register<MyUserRepository[]>(c => new[] 
        { 
            new MyUserRepository("Simpsons", new Dictionary<string, string> {
                { "cburns", "excellent" },
                { "bartsimpson", "Ay caramba" },
                { "homersimpson", "donuts" }
            }), 
            new MyUserRepository("Superheros", new Dictionary<string, string> {
                { "thehulk", "pebbles" },
                { "captainamerica", "redwhiteblue" },
                { "spiderman", "withgreatpower" }
            })
        });
    }
