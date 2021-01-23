    private void button1_Click(object sender, EventArgs e)
        {
            NewForm a = new NewForm(); // my Form
            Action showMethod = () => {
                Invoke(new Action(() => a.Show())); 
            };
            Task t1 = new Task(showMethod);
            Thread t = new Thread(new ThreadStart(t1.Start));
            t.Start(); 
        }
