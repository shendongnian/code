      private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Gerçekten programı kapatmak istiyor musunuz?", "Closing event", MessageBoxButtons.YesNo);
    
            if (dr == DialogResult.No)
                e.Cancel = true;
            else
        //here what you  need  
                Application.Exit()
        }
     
