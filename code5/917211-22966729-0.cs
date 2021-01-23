        protected string ToDate(object wordpressDate)
        {
            DateTime date;
            var culture = new System.Globalization.CultureInfo("pt-BR");
            DateTime.TryParse(wordpressDate.ToString(), culture, System.Globalization.DateTimeStyles.AssumeLocal, out date);
            return date.ToString("dd MMM");
        }
