        {           
            int countforP1 = 0;
            int countforP2 = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == j && gridvalues[j, i] == 1)
                    {
                        countforP1++;
                    }
                    if (i == j && gridvalues[j, i] == 2)
                    {
                        countforP2++;
                    }
                    if (countforP1 == 3)
                    {
                        MessageBox.Show("Player 1 Wins !!");
                        p1score.Text = Convert.ToString(Convert.ToUInt16(p1score.Text) + 1);
                        start_new_game();
                        break;
                    }
                    if (countforP2 == 3)
                    {
                        MessageBox.Show("Player 2 Wins !!");
                        p2score.Text = Convert.ToString(Convert.ToUInt16(p2score.Text) + 1);
                        start_new_game();
                        break;
                    }
                }
            }
        }
