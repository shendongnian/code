    void Form1_Load(object sender, EventArgs e)
    {
        Progress<string> progress = new Progress<string>(updateText);
        Thread thread = new Thread(() => NoteThreader.DoWork(progress));
        thread.Start();
    }
    public class NoteThreader
    {
        public static void DoWork(IProgress<string> progress)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);//placeholder for real work
                progress.Report(i.ToString());
            }
        }
    }
