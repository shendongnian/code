     public class S_Matrix
     {
         public int size_C, size_R;
         public List<entries_R> entry_R;
     
         public S_Matrix(int c, int r)
         {
             this.size_C = c;
             this.size_R = r;
             // entry_R keeps being uninitialised
         }
     }
