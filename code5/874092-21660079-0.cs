    class IPV4Adress
    {
          public int BlockA {get; set;}
          public int BlockB {get; set;}
          public int BlockC {get; set;}
          public int BlockD {get; set;}
          
          public IPV4Adress(string input)
          {
               If(String.IsNullOrEmpty(input))
                    throw new ArgumentException(input);
               
               int[] parts = input.Split(new char{',', '.'}).Select(Int32.Pase).ToArray();
               BlockA = parts[0];
               BlockB = parts[1];
               BlockC = parts[2];
               BlockD = parts[3];
          }
          public override ToString()
          {
               return String.Format("{0}.{1}.{2}.{3}",BlockA, BlockB, BlockC, BlockD);
          }        
    }
