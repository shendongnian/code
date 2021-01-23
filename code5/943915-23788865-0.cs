       public struct Model
       {
          public int B;
          public int C;
          public int D;
    
          public Model(Dto dto)
          {
             B = dto.B;
             C = dto.C;
             D = dto.D;
          }
    
          static public implicit operator Model(Dto dto)
          {
             return new Model(dto);
          }
       }
