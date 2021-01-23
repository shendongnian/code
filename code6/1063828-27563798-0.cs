    System.Timers.Timer timer = new System.Timers.Timer(500);
            timer.Elapsed += (s, e) => { 
                this.Invoke((MethodInvoker)delegate { comboBox1.SelectedIndex = (comboBox1.SelectedIndex + 1) % comboBox1.Items.Count; });
            };
            timer.Start();
