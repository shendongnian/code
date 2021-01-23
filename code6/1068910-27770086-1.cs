    // change the folllowing
    [NotMapped]
    public string Month{get; set;}
    [NotMapped]
    public int Year{get; set;}
    // add this property to use it for EntityFramework mapping
    public string Date
    {
        get
        {
            return ToString();
        }
        set
        {
            if (!string.IsNullOrEmpty(Date))
                {
                    if (Date == "Present")
                        Month = "Present";
                    else
                    {
                        var split = Date.Split(' ');
                        Month = split[0];
                        Year = Convert.ToInt32(split[1]);
                    }
                }
            }
        }
