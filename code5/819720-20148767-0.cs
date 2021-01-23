    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace throw_test
    {
        class Program
        {
            static void Main(string[] args)
            {
                Program p = new Program();
                p.Run();
            }
            public delegate void SafeRunDelegate(object sender, EventArgs e);
            public void Run()
            {
                this.SafeRun(this.MyMethodToSafelyRun);
            }
            public void SafeRun(SafeRunDelegate d)
            {
                if (d != null)
                    d(this, new EventArgs());
            }
            public void MyMethodToSafelyRun(object sender, EventArgs e)
            {
            }
        }
    }
