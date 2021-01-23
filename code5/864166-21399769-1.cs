    public class Country : IComparer
    {
         public string Name { get; set; }
         public string Capital { get; set; }
         public int Population { get; set; }
         int IComparer.Compare(object a, object b)
         {
            Country c1=(Country )a;
            Country c2=(Country )b;
            if (c1.Name < c2.Name )
               return 1;
            if (c1.Name > c2.Name )
               return -1;
            else
               return 0;
         }
    }
