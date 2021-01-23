            var res = await Task.Run(() =>
                    {
                        Thread.Sleep(2000); // perform long calculation
                        return 2 * 2;
                    }
                );
            MessageBox.Show(res.ToString(CultureInfo.InvariantCulture)); // displays 4
