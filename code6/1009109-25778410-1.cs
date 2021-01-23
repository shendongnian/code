       List<Material> list = new List<Material>();
                list.Add(new BendingMaterial());
                list.Add(new OtherMaterial());
    
               foreach (Material m in list)
               {
                   if (m is BendingMaterial)
                   {
                       string x = (m as BendingMaterial).Bendability;
                   }
                   if (m is OtherMaterial)
                   {
                       bool y = (m as OtherMaterial).IsOther;
                   }
               }
