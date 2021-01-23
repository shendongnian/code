    public void run(object sender, RoutedEventArgs e)
            {
                dataSource = new List<BindData>();
                dataSource.Clear();
                int min; int.TryParse(from.Text, out min);
                int max; int.TryParse(to.Text, out max);
                List<int> numbers = new List<int>();
                for (int i = min; i <= max; i++)
                {
                    numbers.Add(i);
                }
                int checknext = 2;
                while (checknext < Math.Sqrt(max))
                {
                    for (int i = numbers.Count - 1; i >= 0; i--)
                    {
                        if (!(numbers[i] == checknext))
                        {
                            if (numbers[i] % checknext == 0)
                                numbers.RemoveAt(i);
                        }
                    }
                    checknext++;
                }          
                for (int i = 0; i < numbers.Count; i++)
                {           
                    dataSource.Add(new BindData() { number = numbers[i].ToString() });
                }
                this.lstbx.ItemsSource = dataSource;
            }
