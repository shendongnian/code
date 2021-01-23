     public  static void main(String args[])
            {
                Hashtable hm = new Hashtable();
                
                int[] a = new int[] { 1, 2, 3, 4, 5 };
                Integer[] b = new Integer[]{ 2, 4, 6, 7, 8 };
                int[] c = new int[] { 3, 4, 5, 6, 9 };
                for (int i = 0; i <= a.length - 1; i++)
                {
                    hm.put(i,a[i]);
                }
             for(int k:b)
             {
                 if (hm.contains(k))
                    {
                       for(int j:c)
                       {
                            if (k==j)  //here is the change
                            {
                                System.out.print(j);
                            }
                       }
                    }
             }
          
            }
        }
