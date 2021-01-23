    private void Button1_Click(object sender, EventArgs e)
            {
              bgworker.RunWorkerAsync();
            }
    private void bgworker_DoWork(object sender, DoWorkEventArgs e)
            {
              ConverToPdf(source, commandLocation);
            }
