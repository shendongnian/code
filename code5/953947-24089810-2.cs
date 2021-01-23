     private void hereIsYourAnswer()
        {
            string [] first = { "1", "saka", "2", "1", "1", "3", "saka", "1", "stack", "3" };
            int [] second = { 20, 23, 25, 30, 20, 15, 16, 61, 34, 35 };
            List<String> F = new List<string>();
            List<int> S = new List<int>();
            for (int i = 0; i < first.Length; i++)
            {
                if (F.Contains(first[i]))
                    S[F.IndexOf(first[i])] += second[i];
                else
                {
                    F.Add(first[i]);
                    S.Add(second[i]);
                }
                
            }
            for (int i = 0; i < S.Count; i++)
                MessageBox.Show(F[i] + " = " + S[i].ToString());
                    //Output
                    //1=131
                    //saka=39
                    //2=25
                    //3=50
                    //stack=34
        }
