    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Console.WriteLine(clearHistoryOnQuitToolStripMenuItem.CheckState.ToString());
            if (clearHistoryOnQuitToolStripMenuItem.Checked)
            {
                System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 255");
            }
        }
