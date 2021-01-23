            int[] numbers = new int[] { 1, 2, 3, 2, 4, 8, 9, 7 };
            String orderedNumbers = String.Empty;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == 0 || numbers[i] > numbers[i - 1])
                {
                    orderedNumbers += numbers[i].ToString();
                }
                else
                {
                    orderedNumbers += System.Environment.NewLine + numbers[i].ToString();
                }
            }
            MessageBox.Show(orderedNumbers);
