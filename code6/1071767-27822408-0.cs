       {
        public class Buffer
        {
            private delegate void Display(int v, ProgressBar f );
            private Queue<Toy> Toys = new Queue<Toy>(); 
            private object MyLock = new object();
            private int max;
            private int lenght; 
            private ProgressBar progressbar1; 
            public Buffer(ProgressBar r)
            {
                this.progressbar1 = r; 
                this.max = 10;
                this.lenght = Toys.Count; 
                
            }
            public void writeMethod(Toy toy)
            {
                lock (MyLock)
                {
                   if (Toys.Count >= max)
                   {
                       Monitor.Wait(MyLock);
                   }
                   if(Toys.Count <= max)
                   {
                       Toys.Enqueue(toy); 
                      progressbar1.Invoke(new Display(Disp), new object[] {Toys.Count, progressbar1});
                   }
    
                    Monitor.PulseAll(MyLock);
                   
         
                    MessageBox.Show("Que contains these items" + Toys.Count); 
                }
            }
    
            public void readMethod()
            {
                lock (MyLock)
                {
                    if(Toys.Count == 0)
                    {
                        Monitor.Wait(MyLock); 
                    }
                    Toys.Dequeue(); 
                    Monitor.PulseAll(MyLock); 
    
                }
                
            }
            public void Disp(int I, ProgressBar l)
            {
                progressbar1.Value += I; 
            
            }
        }
    }
