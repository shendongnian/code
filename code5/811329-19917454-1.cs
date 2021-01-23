     List<TextBox> tBoxes = new List<TextBox>();
            tBoxes.Add(number1);
            tBoxes.Add(number2);
            tBoxes.Add(number3);
            tBoxes.Add(number4);
            tBoxes.Add(number5);
            List<int> allNums = new List<int>();
            foreach (TextBox item in tBoxes)
            {
                allNums.Add(int.Parse(item.Text));
            }
            allNums.Sort();
            for (int i = 0; i < tBoxes.Count - 1; i++)
            {
                tBoxes[i].Text = allNums[i].ToString();
            }
