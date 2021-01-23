    private void btnAdd_Click(object sender, EventArgs e)
        {
            lstNumbers.Items.Add(txtAddNumbers.Text);
            txtAddNumbers.Clear();
            int iList = 0, result = 0;
            while (iList < lstNumbers.Items.Count)
            {
                result += Convert.ToInt32(lstNumbers.Items[iList++]);
            }
         
            lblSum.Text = "Sum : " + Convert.ToString((double)result);   
            
            //you can also calculate Average
            lblMean.Text = "Mean : " + Convert.ToString((double)result / iList);
        }
