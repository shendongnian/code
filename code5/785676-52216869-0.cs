        private void button1_Click(object sender, EventArgs e)
        {
            txtResult.Text=GenerateMatrix(Int32.Parse(txtRow.Text), Int32.Parse(txtColumn.Text));
        }
        private string GenerateMatrix(int Row,int Column)
        {
            string matrix = string.Empty;
            string Result = string.Empty;
            int nxtline=0;
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    if (nxtline==Column)
                    {
                        matrix = matrix + Environment.NewLine;
                        nxtline = 0;
                    }
                    matrix = matrix+"*";
                    nxtline = nxtline + 1;
                }
            }
            Result = matrix;
            return Result;
        }
