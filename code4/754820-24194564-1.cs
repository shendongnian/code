    <pre>Operation			Time
    <code>Math.Exp(x)</code>		180 ns (nanoseconds)
    <code>Math.Pow(y, x)</code>		440 ns
    <code>Math.Exp(x*ln10)</code>	160 ns</pre>
    
    Times are per 10x calls to Math functions.
    
What I don't understand is why the time for including a multiply in the loop, before entry to Exp(), consistently produces shorter times, unless there's a bug in this code, or the algorithm is value dependent?<br><br>
    The program follows.<br>
    
     
    
       namespace _10X {
        	public partial class Form1 : Form {
        		int nLoops = 1000000;
        		int ix;
        
        		// Values - Just to not always use the same number, and to confirm values.
        		double[] x = { 0.5, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5 };
        
        		public Form1() {
        			InitializeComponent();
        			Proc();
        		}
        
        		void Proc() {
        			double y;
        			long t0;
        			double t1, t2, t3;
        
        			t0 = DateTime.Now.Ticks;
        			for (int i = 0; i < nLoops; i++) {
        				for (ix = 0; ix < x.Length; ix++)
        					y = Math.Exp(x[ix]);
        			}
        			t1 = (double)(DateTime.Now.Ticks - t0) * 1e-7 / (double)nLoops;
        
        			t0 = DateTime.Now.Ticks;
        			for (int i = 0; i < nLoops; i++) {
        				for (ix = 0; ix < x.Length; ix++)
        					y = Math.Pow(10.0, x[ix]);
        			}
        			t2 = (double)(DateTime.Now.Ticks - t0) * 1e-7 / (double)nLoops;
        
        			double ln10 = Math.Log(10.0);
        			t0 = DateTime.Now.Ticks;
        			for (int i = 0; i < nLoops; i++) {
        				for (ix = 0; ix < x.Length; ix++)
        					y = Math.Exp(x[ix] * ln10);
        			}
        			t3 = (double)(DateTime.Now.Ticks - t0) * 1e-7 / (double)nLoops;
        
        			textBox1.Text = "t1 = " + t1.ToString("F8") + "\r\nt2 = " + t2.ToString("F8")
        						+ "\r\nt3 = " + t3.ToString("F8");
        		}
        
        		private void btnGo_Click(object sender, EventArgs e) {
        			textBox1.Clear();
        			Proc();
        		}
        	}
        }
    
    </code>
    
So I think I'm going with Math.Exp(x * ln10) until someone finds the bug...
