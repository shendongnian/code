      class Suspect
      {
          public Suspect(int id)
          {
              CoSuspects = new HashSet<Suspect>();
              this.ID = id;
          }
      	  public int ID { get; set; }
          public HashSet<Suspect> CoSuspects { get; set; }
      }
      int[][] GetRandomData()
      {
          var list = new List<int[]>();
          var random = new Random();
      
      	for (int i = 0; i < 100; i++)
          {
              list.Add(new[] { random.Next(10), random.Next(10) });
          }
      
          return list.ToArray();
      }
      int[] GetSuspects()
      {
          var random = new Random();
      
          var list = new List<int>();
      
      	for (int i = 0; i < 3; i++)
          {
              list.Add(random.Next(10));
          }
          return list.ToArray();
      }
