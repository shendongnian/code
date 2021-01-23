        public string Metod(Something data)
        {
            DateTimeOffset sDate = DateTimeOffset.Parse(data.date1);
            DateTimeOffset eDate = DateTimeOffset.Parse(data.date2);
            return _someService.GetService(data.Id, sDate, eDate);
        }
