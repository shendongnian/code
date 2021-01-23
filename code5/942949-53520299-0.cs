            for (int i = 0; i < names.Length; i++)
            {
                string temp = "";
                for (int j = i + 1; j < names.Length; j++)
                {
                    if (names[i].CompareTo(names[j]) > 0)
                    {
                        temp = names[j];
                        names[j] = names[i];
                        names[i] = temp;
                    }
                }
            }
