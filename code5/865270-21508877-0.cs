    int J = 0;
            if (max != 1)
            {
                for (int iii = 0; iii < output.Length -1; iii++)
                    {
                        if ((output[iii] == imax) && (output[iii + 1] == jmax))
                        {
                            temp = temp + 1;
                            output[J] = Convert.ToByte(temp);
                            J = J + 1;
                            iii = iii + 1;
                        }
                        else
                        {
                            output[J] = output[iii];
                            J = J + 1;
                            output[J] = output[iii + 1];
                        }
                    }
            }
