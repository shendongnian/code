    private void ServerProc_ErrorDataReceived(object sender, DataReceivedEventArgs e)
    {
        Invoke(new Action(() =>
        {
            if (e.Data!=null && e.Data.Contains("nastything"))
            {
                System.Windows.Forms.MessageBox.Show("Something nasty happened in console ");
            }
            if (e.Data!=null) f2.richTextBox1.AppendText(e.Data + "\n");
        }));
    }
