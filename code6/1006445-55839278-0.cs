     public class MonthAndYear 
        {        
            private string _monthAndYear;
       
            public string Month { get; set; }
            public IDictionary<string, int> Months { get; set; }
            public int Year { get; set; }
            public string MonthYear
            {
                get
                {
                    return string.Concat(Month," ", Year);
                }
                set
                {
                    _monthAndYear = value;
                }
            }
    
            public MonthAndYear()
            {
                Months = new Dictionary<string, int>();
                Months.Add("January", 1);
                Months.Add("February", 2);
                Months.Add("March", 3);
                Months.Add("April", 4);
                Months.Add("May", 5);
                Months.Add("June", 6);
                Months.Add("July", 7);
                Months.Add("August", 8);
                Months.Add("September", 9);
                Months.Add("October", 10);
                Months.Add("November", 11);
                Months.Add("December", 12);
            }        
    
            public int MonthInteger(string month)
            {
                if (Months.ContainsKey(month))
                {
                    return Months[month];
                }
                else
                    return 1;
            }
    
            public List<MonthAndYear> SortMonthAndYear(List<string> _monthYearList)
            {           
                List<MonthAndYear> _sortedMonthAndYear = new List<MonthAndYear>();
    
                foreach (var _monthYear in _monthYearList)
                {
                    _sortedMonthAndYear.Add
                    (
                        new MonthAndYear
                        {
                            Month = _monthYear.Substring(0, _monthYear.IndexOf(' ')),
                            Year = Convert.ToInt32(_monthYear.Substring(Math.Max(0, _monthYear.Length - 4)))
                        }
                    );
                }            
                return _sortedMonthAndYear.OrderBy(y => y.Year).ThenBy(m => m.MonthInteger(m.Month)).ToList(); 
            }
    
        }
