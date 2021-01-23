    private double m_quiz1;
    public double Quiz1
    {
        get { return m_quiz1; }
        set 
        {
            if (value > 0 && value < 101)
            {
                m_quiz1= value;
            }
            else
            {
                m_quiz1= 0;
            }
        }
    }
