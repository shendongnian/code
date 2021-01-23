        public static string ExpandingDates(string _date)
        {
            if (string.IsNullOrWhiteSpace(_date))
            {
                return "";
            }
            else
            {
                try
                {
                    _date = _date.Replace("\\", "-");
                    _date = _date.Replace(",", "-");
                    if (!_date.Contains(".") & !_date.Contains("/") & !_date.Contains("-"))
                    {
                        if (_date.Length == 6)
                        {
                            _date = _date.Insert(2, "-").Insert(5, "-");
                        }
                        else if (_date.Length == 8)
                        {
                            _date = _date.Insert(2, "-").Insert(5, "-");
                        }
                    }
                    try
                    {
                        _date = Convert.ToDateTime(_date).ToShortDateString();
                    }
                    catch { _date = ""; }
                }
                catch
                {
                    _date = "";
                }
                return _date;
            }
        }
