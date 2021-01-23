     if (number % 2 == 0 && number <= 1000 && number >= 10)
                        {
                            for (int i = 3; i < number - 3; i += 2)
                            {
                                if(isprime(i) && isprime(number-i))
                                {
                                holder += "        " + i + " + " + (number - i) + "; ";
                                holder2 = "        " + i + " + " + (number - i) + "; ";
                                lvContainer.Items.Add(holder2);
                                }
                            }
                            MessageBox.Show(holder);
                        }
                        if (number % 2 == 0 && number <= 8 && number >= 4)
                        {
                            for (int i = 3; i < number; i += 2)
                            {
                                if(isprime(i) && isprime(number-i))
                                {
                                holder += "        " + i + " + " + (number - i) + ";";
                                holder2 = "        " + i + " + " + (number - i) + ";";
                                lvContainer.Items.Add(holder2);
                                }
                            }
                            MessageBox.Show(holder);
                        }
