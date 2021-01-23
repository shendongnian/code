    private void comparaeapagarowsiguais(DataTable table1)
        { int a=0; int b=0;
            foreach (DataRow row1 in table1.Rows)
            {  a++; 
               b=0;
                foreach (DataRow row2 in table1.Rows)
                {  b++;
                    if(a!=b)
                     {
                    var array1 = row1.ItemArray;
                    var array2 = row2.ItemArray;
    
                    if (array1.SequenceEqual(array2))
                    {
                        table1.Rows.Remove(row2);
                    }
                   } 
    
                }
            }
    
    
        }
