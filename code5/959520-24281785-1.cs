    try
            {
                ViewModel s = ViewModel.Instance;
                s.NameValue.TestName = "Alicia";
                this.DataContext = s;
                this.TextName.DataContext = s;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error" + e.Message);
            }
