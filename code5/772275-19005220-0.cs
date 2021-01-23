        int height = this.Height;
        CalculateFormHeight(ref height);
        this.Size = new Size(this.Width, height);
         
        private void CalculateFormHeight(ref int height)
        {
            if (dataGridViewToDisplay != null && dataGridViewToDisplay.Rows != null)
            {
                if (dataGridViewToDisplay.Rows.Count >= 15)
                {
                    height = dataGridViewToDisplay.Rows[0].Height * 18 + splitContainer1.Panel2.Height;
                }
                else if (dataGridViewToDisplay.Rows.Count < 15)
                {
                    height = dataGridViewToDisplay.Rows[0].Height * (dataGridViewToDisplay.Rows.Count + 3) + splitContainer1.Panel2.Height;
                }
            }
        }
