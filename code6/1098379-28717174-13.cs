     private int autoValue = 0;     
     public void AddBlah(string blahh)
     {
          TheList.Add(new Blah{id = autovalue++, blahh = blahh});
     }
     public void AddDoh(string dohh, string mahh)
     {
          TheList.Add(new Doh{id = autovalue++, dohh = dohh, mahh = mahh});
     }
