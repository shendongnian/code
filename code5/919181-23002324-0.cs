        private string _text;
        public async void UpdateCollection()
        {
            _text = searchtextvaluehere;
            await Task.Delay(200);
            if (_text == searchtextvaluehere)
            {
                using (var ctx =  DB.GET())
                {
                    Clients.Clear();
                    Clients.AddRange(ctx.Businesses);
                }
            }
        }
