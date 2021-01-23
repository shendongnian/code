    private void Call()
            {
                List<int> numbers = GetList<int>(l =>
                {
                    l.Add(1);
                    l.Add(2);
                    //etc
                });
                MessageBox.Show("Numbers amount " + numbers.Count);
            }
    
            private List<T> GetList<T>(Action<List<T>> initList)
            {
                List<T> list = Activator.CreateInstance<List<T>>();
                initList(list);
                return list;
            }
