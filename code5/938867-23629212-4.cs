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
          while(n_array[i]!=null && n_array[i].V < value)
          {
              i++;
          }
          /*
            remember to check special conditions like if this new item is going to be head or going
            to be last item in the list or both in case of empty list
          */
          item .L = n_array[i].L;
          item .R = n_array[i];
          n_array[i].L = item;
          return item;
    }
 
