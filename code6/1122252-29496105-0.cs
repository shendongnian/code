    public DateTime Deadline { get; set; }
    public Color Forecolor
    {
        get
        {
            if (DateTime.Now > Deadline)
                return Colors.Red;
            else
                return Colors.Green;
        }
    }
