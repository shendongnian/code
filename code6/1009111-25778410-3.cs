       List<T> ListMaterial = new List<Material>();
                ListMaterial .Add(new BendingMaterial());
                ListMaterial .Add(new OtherMaterial());
    
               foreach (Material m in ListMaterial )
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
               //more code
