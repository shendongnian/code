    public void Update_Click(object sender, EventArgs e)
        {
            using (PccBiometricsHandler.Form1 ShowProgress = new PccBiometricsHandler.Form1())
            {
                menu.Items[2].Enabled = false;
                ShowProgress.FormClosed += new FormClosedEventHandler(MyForm_FormClosed); //Attached the event handler before firing ShowDialog
                ShowProgress.ShowDialog();
            }
        }
