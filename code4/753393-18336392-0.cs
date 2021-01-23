        public void Load()
        {
            matchList = new List<GetMatchDetailsDC>();
            matchList = proxy.GetMatch().ToList();
            foreach (EfesBet.DataContract.GetMatchDetailsDC match in matchList)
            {
                App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                {
                    _matchObsCollection.Add(match);
                });
            }
        }
