      private void RunScript(double z, int x, List<double> y, DataTree<double> u, ref object A)
      {
        System.Threading.Tasks.Task<double[]> th1 = System.Threading.Tasks.Task<double[]>.Factory.StartNew(() => mP(u.Branch(0).ToArray(), x, z));
        System.Threading.Tasks.Task<double[]> th2 = System.Threading.Tasks.Task<double[]>.Factory.StartNew(() => mP(u.Branch(1).ToArray(), x, z));
        System.Threading.Tasks.Task<double[]> th3 = System.Threading.Tasks.Task<double[]>.Factory.StartNew(() => mP(u.Branch(2).ToArray(), x, z));
        System.Threading.Tasks.Task<double[]> th4 = System.Threading.Tasks.Task<double[]>.Factory.StartNew(() => mP(u.Branch(3).ToArray(), x, z));
        System.Threading.Tasks.Task<double[]> th5 = System.Threading.Tasks.Task<double[]>.Factory.StartNew(() => mP(u.Branch(4).ToArray(), x, z));
        System.Threading.Tasks.Task<double[]> th6 = System.Threading.Tasks.Task<double[]>.Factory.StartNew(() => mP(u.Branch(5).ToArray(), x, z));
        System.Threading.Tasks.Task<double[]> th7 = System.Threading.Tasks.Task<double[]>.Factory.StartNew(() => mP(u.Branch(6).ToArray(), x, z));
        System.Threading.Tasks.Task<double[]> th8 = System.Threading.Tasks.Task<double[]>.Factory.StartNew(() => mP(u.Branch(7).ToArray(), x, z));
    
        List<double> list = new List<double>();
    
        list.AddRange(th1.Result);
        list.AddRange(th2.Result);
        list.AddRange(th3.Result);
        list.AddRange(th4.Result);
        list.AddRange(th5.Result);
        list.AddRange(th6.Result);
        list.AddRange(th7.Result);
        list.AddRange(th8.Result);
    
    
        A = list;
    
    
      }
