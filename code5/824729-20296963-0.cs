            while (products.Peek() != -1)
            {
                category[index] = products.ReadLine();
                if(cBSearch.SelectedItem.ToString().Equals(category[index]))
                {
                name[index] = products.ReadLine();
                description[index] = products.ReadLine();
                price[index] = products.ReadLine();
                }
                index++;
            }
