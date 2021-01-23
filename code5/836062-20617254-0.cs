    ArrayList Test = new ArrayList { "10,10,20,20,30,35,40,50,45,50,45,50,50,50,20,20,45,90,85,85" };
            int[] earned = new int[Test.Count / 2];
            int[] Score = new int[Test.Count / 2];
        int Counter = 1; // start at one so earned is the first array entered in to
        foreach (string TestRow in Test)
        {
            if (Counter % 2 != 0) // is the counter even
            {
                int nextNumber = 0;
                for (int i = 0; i < Score.Length; i++) // this gets the posistion for the next array entry
                {
                    if (String.IsNullOrEmpty(Convert.ToString(Score[i])))
                    {
                        nextNumber = i;
                        break;
                    }
                }
                Score[nextNumber] = Convert.ToInt32(TestRow);
            }
            else
            {
                int nextNumber = 0;
                for (int i = 0; i < earned.Length; i++) // this gets the posistion for the next array entry
                {
                    if (String.IsNullOrEmpty(Convert.ToString(earned[i])))
                    {
                        nextNumber = i;
                        break;
                    }
                }
                earned[nextNumber] = Convert.ToInt32(TestRow);
            }
            Counter++
        }
