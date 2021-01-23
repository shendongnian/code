    string dob = DOB.ToString();
    int sum = 0;
                while (true)
                {
                    var list = dob.Where(p => char.IsDigit(p)).ToList();
                    if (list.Count == 1)
                        break;
                    sum = list.Aggregate(0, (a, b) => a + int.Parse(b.ToString()));
                    dob = sum.ToString();
    
                }
