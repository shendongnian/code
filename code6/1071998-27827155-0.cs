    private async void button1_Click(object sender, EventArgs e)
    {
        button1.Enabled = false;
        int konst = Int32.Parse(textBox1.Text);
        double euler = 1;
        int variable = 0;
        int index = 0;
        int factorial = 0;
        double absolute_error;
        variable = konst;
        richTextBox1.Multiline = true;
        richTextBox1.ReadOnly = true;
        richTextBox1.Text = ("---ongoing calculations---");
        while (true)
        {
            try
            {
                if (konst < 1 || konst > 30)
                {
                    throw new ArgumentOutOfRangeException("you have not entered a value between 1 and 30");
                }
                while (variable > 0)
                {
                    await Task.Run(() =>
                    {
                        int iterationMax = 100;
                        while (variable > 0 && iterationMax-- > 0)
                        {
                            if (variable == 1)
                            {
                                factorial = 1;
                            }
                            else
                            {
                                index = variable - 1;
                                factorial = variable;
                                while (index > 0)
                                {
                                    factorial *= index;
                                    index--;
                                }
                            }
                            //promenna--;
                        }
                    });
                    euler += Convert.ToDouble(1) / factorial;
                    richTextBox1.Text = euler.ToString();
                }
            }
            catch (ArgumentOutOfRangeException ae) // exceptions
            {
                MessageBox.Show(ae.Message);
                break;
            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
                break;
            }
            finally
            {
                absolute_error = EulerNumberError.error(euler);
                textBox3.Text = absolute_error.ToString();
                textBox2.Text = euler.ToString();
            }
        }
        button1.Enabled = true;
    }
