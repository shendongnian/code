    using System;
    
    namespace Matrix_Algebra
    {
        public struct S_Matrix_size
        {
            public int size_R, size_C;
            public S_Matrix_size(int r, int c)
            {
                this.size_R = r;
                this.size_C = c;
            }
        }
        
        public class C_Matrix_entries
        {
            private S_Matrix_size _size;
        
            public C_Matrix_entries()
            {
                int r, c;
                Console.WriteLine("Enter number of rows and columns ");
        
                r = Convert.ToInt32(Console.ReadLine());
                c = Convert.ToInt32(Console.ReadLine());
                _size = new S_Matrix_size(r,c);
        
                double[,] entry = new double [_size.size_R,_size.size_C];
        
                Console.WriteLine("Enter the entries from first row [left to right] to the last row ");
                for (int i = 0; i<_size.size_R; i++)
                {
                    Console.WriteLine("Enter the {0} row", i + 1);
                    for (int j = 0; j<_size.size_C;j++)
                    {
                        entry[i, j] = Convert.ToDouble(Console.ReadLine());
                    }
                }       
            }    
        
            public S_Matrix_size Size { get { return _size; } }
        }
    }
    
    namespace Row_Reduce_Algebra
    {
        using Matrix_Algebra;
        public class TEST
        {
            static void Main()
            {
                C_Matrix_entries matrix_no1 = new C_Matrix_entries();
                for (int i = 0; i < matrix_no1.Size.size_R * matrix_no1.Size.size_C; i++)
                {
                    // TODO: something useful
                    Console.WriteLine(i); // FORNOW
                }
             }
        }
    }
