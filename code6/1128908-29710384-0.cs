        private void RunScript(double z, int x, List<double> y, ref object A) {
            var temp = new System.Collections.Concurrent.BlockingCollection<double>();
            System.Threading.Tasks.Parallel.ForEach(y, numb => {
                double r = Math.Pow((numb * x), z);
                temp.Add(r);
            });
            A = temp; // if needed you can A = temp.ToList();
            }
