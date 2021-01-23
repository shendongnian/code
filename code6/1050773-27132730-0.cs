    public class MatrixCalc
    {
        readonly double[,] a, b, c;
        readonly int a_rows, a_cols, b_rows, b_cols, c_rows, c_cols;
        bool result_ok;
        int thread_count;
        BackgroundWorker bw1, bw2;
        AutoResetEvent re;
        public MatrixCalc(double[,] a, double[,] b, double[,] c)
        {
            a_rows=a.GetLength(0);
            a_cols=a.GetLength(1);
            b_rows=b.GetLength(0);
            b_cols=b.GetLength(1);
            c_rows=c.GetLength(0);
            c_cols=c.GetLength(1);
            // keep references of arrays
            this.a=a;
            this.b=b;
            this.c=c;
        }
        public void Multiply()
        {
            result_ok=false;
            this.bw1=new BackgroundWorker();
            this.bw2=new BackgroundWorker();
            this.re=new AutoResetEvent(false);
            bw1.WorkerSupportsCancellation=true;
            bw1.DoWork+=new DoWorkEventHandler(bw_DoWork);            
            bw1.RunWorkerCompleted+=new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw1.RunWorkerAsync(0);
            bw2.WorkerSupportsCancellation=true;
            bw2.DoWork+=new DoWorkEventHandler(bw_DoWork);
            bw2.RunWorkerCompleted+=new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw2.RunWorkerAsync(1);
            re.WaitOne();
            re.WaitOne();
        }
        public bool OK { get { return result_ok; } }
        public void Cancel()
        {
            bw1.CancelAsync();
            bw2.CancelAsync();
            re.WaitOne();
            re.WaitOne();
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            thread_count--;
            this.result_ok=(!e.Cancelled)&&(thread_count==0);
        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            thread_count++;
            if(!e.Cancel)
            {
                var offset=(int)e.Argument;
                for(int i=0; i<a_rows; ++i)
                {
                    // This is the trick. Start from column 0 or 1
                    // and skip over one column.
                    //
                    // Thread 1 Columns : 0,2,4,6,...
                    // Thread 2 Columns:  1,3,5,7,...
                    //
                    for(int j=offset; j<b_cols; ++j, ++j)
                    {
                        var sum =InnerLoop(i, j);
                        lock(c)
                        {
                            c[i, j]=sum;
                        }
                        Debug.WriteLine("C[{0},{1}]={2}", i, j, sum);
                    }
                }
            }
            re.Set();
        }
        public double InnerLoop(int a_row, int b_col)
        {
            double sum=0;
            for(int i=0; i<a_cols; i++)
            {
                sum+=a[a_row, i]*b[i, b_col];
            }
            return sum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            const int N=5;
            double[,] a = new double[N,N], b=new double[N,N], c=new double[N,N];
            MatrixCalc calc=new MatrixCalc(a, b, c);
            // Fill in some values into arrays
            for(int i=0; i<N; i++)
            {
                a[i, i]=1;
                b[i, i]=1;
                if(i>0)
                {
                    b[i, 0]=-i;
                    a[0, i]=i;
                }
            }
            calc.Multiply();
            Debug.WriteLine("Result: {0}", calc.OK);
        }
    }
