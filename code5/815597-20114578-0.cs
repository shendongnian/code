     BackgroundWorker bg = new BackgroundWorker();
     Boolean stopwork = true;
     Private void btnYes_Click(object sender, EventArgs e)
            {
                if (DialogResult.Yes == MessageBox.Show(clsGlobalObjectRefrances.OMessageString.SureWant2UpdateMarks, "", MessageBoxButtons.YesNo))
                {
                    try
                    {
                      
                        bg.DoWork += bg_DoWork;
                        bg.RunWorkerCompleted += bg_RunWorkerCompleted;
                        bg.RunWorkerAsync();
                        pgbUpdateMarks.Maximum = 60;
                        Stopwatch st = new Stopwatch();
                        st.Start();
                        while(stopwork)
                        {
                            pgbUpdateMarks.Value = st.Elapsed.Seconds;
                        }
                        pgbUpdateMarks.Value = 0;
                        MessageBox.Show("Executed sucessfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
