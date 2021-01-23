        private void button2_Click(object sender, EventArgs e) {
            var useworker = checkBox1.Checked;
            System.Threading.ThreadPool.QueueUserWorkItem((_) => {
                var lst = new List<object>();
                for (int ix = 0; ix < 500 * 1024 * 1024 / (IntPtr.Size * 3); ++ix) {
                    lst.Add(new object());
                }
                lst.Clear();
                if (useworker) {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                else {
                    this.BeginInvoke(new Action(() => {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }));
                }
            });
        }
