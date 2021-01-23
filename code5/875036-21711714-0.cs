    public partial class Form1 : Form
    {
        int ArrayDim1 = 50;
        int ArrayDim23 = 500;
        int ParallelSplit = 50;
        int DoSomethingSize = 100;
        Double sqRoot = 0;
        Single[, ,] multidim = null;
        Single[] singleDim = null;
        Single[][][] jagged = null;
        ParallelOptions po = new ParallelOptions() { MaxDegreeOfParallelism = 36 };
        public Form1()
        {
            InitializeComponent();
            multidim = new Single[ArrayDim1, ArrayDim23, ArrayDim23];
            for (int x = 0; x < ArrayDim1; x++)
                for (int y = 0; y < ArrayDim23; y++)
                    for (int z = 0; z < ArrayDim23; z++)
                        multidim[x, y, z] = 1;
            singleDim = new Single[ArrayDim1 * ArrayDim23 * ArrayDim23];
            for (int i = 0; i < singleDim.Length; i++)
                singleDim[i] = 1;
            jagged = new Single[ArrayDim1][][];
            for (int i = 0; i < ArrayDim1; i++)
            {
                jagged[i] = new Single[ArrayDim23][];
                for (int j = 0; j < ArrayDim23; j++)
                {
                    jagged[i][j] = new Single[ArrayDim23];
                }
            }
        }
        private void btnGO_Click(object sender, EventArgs e)
        {
            int loopcount = 1;
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < loopcount; i++)
            {
                TestMultiDimArray(multidim);
            }
            textBox1.Text = DateTime.Now.Subtract(startTime).TotalMilliseconds.ToString("#,###");
            startTime = DateTime.Now;
            for (int i = 0; i < loopcount; i++)
            {
                TestSingleArrayClean(singleDim);
            }
            textBox2.Text = DateTime.Now.Subtract(startTime).TotalMilliseconds.ToString("#,###");
            startTime = DateTime.Now;
            for (int i = 0; i < loopcount; i++)
            {
                TestJaggedArray(jagged);
            }
            textBox3.Text = DateTime.Now.Subtract(startTime).TotalMilliseconds.ToString("#,###");
        }
        public void TestJaggedArray(Single[][][] multi)
        {
            Parallel.For(0, ArrayDim1, po, x =>
            {
                for (int y = 0; y < ArrayDim23; y++)
                {
                    for (int z = 0; z < ArrayDim23; z++)
                    {
                        DoComplex();
                        multi[x][y][z] = Convert.ToSingle(Math.Sqrt(123412341));
                    }
                }
            });
        }
        public void TestMultiDimArray(Single[, ,] multi)
        {
            Parallel.For(0, ArrayDim1, po, x =>
                {
                    for (int y = 0; y < ArrayDim23; y++)
                    {
                        for (int z = 0; z < ArrayDim23; z++)
                        {
                            DoComplex();
                            multi[x, y, z] = Convert.ToSingle(Math.Sqrt(123412341));
                        }
                    }
                });
        }
        public void TestSingleArrayClean(Single[] single)
        {
            Parallel.For(0, single.Length, po, y =>
                {
                    //System.Diagnostics.Debug.Print(y.ToString());
                    DoComplex();
                    single[y] = Convert.ToSingle(Math.Sqrt(123412341));
                });
        }
        public void DoComplex()
        {
            for (int i = 0; i < DoSomethingSize; i++)
            {
                sqRoot = Math.Log(101.101);
            }
        }
    }
