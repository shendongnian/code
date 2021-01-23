    public void Main()
    {
       Ps pc = new Ps();
       pc.items.Add(new Pr { Name = "Name1",Comp = { new Comp { Type = "Type1", Attr = { new Attr { Type = "Combo"} } } } });
       pc.items.Add(new Sep{ Sep = "AutoSkew1" });
       pc.items.Add(new Pr { Name = "Name3", Comp = { new Comp { Type = "Type3", Attr = { new Attr { Type = "Rb"} } } } });
       pc.items.Add(new Sep { Sep = "AutoSkew2" });
       var xml = pc.items.ToXml();
    }
