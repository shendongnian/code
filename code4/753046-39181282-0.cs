    Legend L1 = chart10.Legends[0];
    Legend L2 = new Legend("Legend Two");
    L2.CustomItems.Add(new LegendItem("Legens Item 2.1", Color.Fuchsia, ""));
    L2.Position = new ElementPosition(L1.Position.X, L1.Position.Bottom + 1, 
                                      L1.Position.Width, L1.Position.Height);
