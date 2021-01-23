    public class sqr_Matrix_3x3                                                                
            {
                private double[,] _entries = new double[3, 3];
                public C_sqr_Matrix_3x3(double a,double b,double c,double d,double 
                e,double f,double g,double h,double i)
                {
                    this._entries[1, 1] = a;
                    this._entries[1, 2] = b;
                    this._entries[1, 3] = c; <-- Error
                    this._entries[2, 1] = d;
                    this._entries[2, 2] = e;
                    this._entries[2, 3] = f; <-- Error
                    this._entries[3, 1] = g; <-- Error
                    this._entries[3, 2] = h; <-- Error 
                    this._entries[3, 3] = i; <-- Error 
                }
