    }
        private void button1_Click(object sender, EventArgs e)
        {
            Class1 c = new Class1();
            progressBar1.Maximum = 1000;
            for(int i = 0; i < 1000; i++)
            {
                Thread.Sleep(10);
                c.IncreaseProgress(progressBar1);
            }
        }
    }
    class Class1
    {
        public void IncreaseProgress(ProgressBar p)
        {
            p.Value++;
        }
    }
