            List<double> lst = new List<double>();
            string strInput2 = txtInput2.Text;
            for (int i = 0; i < strInput2.Length; i++)
            {
                double dbl = Convert.ToDouble(txtInput1.Text) * Convert.ToDouble(strInput2[strInput2.Length - (i + 1)].ToString());
                string zeros = new String('0', i);
                lst.Add(Convert.ToDouble(dbl + zeros));
                richTextBoxResult.Text += lst[i] + Environment.NewLine;
            }
            richTextBoxResult.Text += "________________" + Environment.NewLine;
            richTextBoxResult.Text += lst.Sum();
