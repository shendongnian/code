        if (IsSync)
        {
            for (int i = 0; i < _num; i++)
            {
                _withdrawers.Add(new Withdrawer(Users.Count, _due, _pause));
                _threads.Add(new Thread(delegate()
                   { _withdrawers[i].Withdraw(ref Users, _sum, true); }));
                _threads[i].Name = i.ToString();
                _threads[i].Start();
                _threads[i].Join();
            }
        }
        else
        {
            for (int i = 0; i < _num; ++i)
            {
                _withdrawers.Add(new Withdrawer(Users.Count, _due, _pause));
                _threads.Add(new Thread(delegate()
                    { _withdrawers[i].Withdraw(ref Users, _sum, false); }));
                _threads[i].Name = i.ToString();
                _threads[i].Start();
            }
        }
