       bool isLabelClicked = false;
       private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (isLabelClicked)
            {
                label1.Text = ((char)e.KeyValue).ToString();
                isLabelClicked = false;
            }
        }
        
        private void label1_Click(object sender, EventArgs e)
        {
            isLabelClicked = true;
        }
