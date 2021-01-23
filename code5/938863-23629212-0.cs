    public static int[] notearray(int[] array)
    {
          n_array = new cN[array.Length];
          for(int i=0 ; i<array.Length ; i++)
          {
              n_array[i] = insertItem(array[i]);
          }
    }
    private static cN insertItem(int value)
    {
          cN item = new cN(null,null,value)
          int i=0;
          while(n_array[i].V < value)
          {
              i++;
          }
          item .L = n_array[i].L;
          item .R = n_array[i];
          n_array[i].L = item;
          //TODO: check if this new item is head
          return item;
    }
 
