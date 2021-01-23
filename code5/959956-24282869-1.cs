               static public void CreateForm()
                {
                  Form2 f2 = new Form2();
                  f2.Invoke(new MethodInvoker(delegate()
                  {
                     
                        f2.Show();
                  }));
                }
