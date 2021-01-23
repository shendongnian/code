    private List<Rectangle> generateRectList()
    {
        var aRectZero = new List<Rectangle>();
        for (int i = 0; i < 4; i++)
            aRectZero.Add(m_Rectdef);
        return aRectZero;
    }
    private void ResetAllData()
    {        
        m_aRectWBLD.Clear();
        for (int i = 0; i < 2; i++)
        {
            m_aRectWBLD.Add(generateRectList());
        }
        m_aRectWBLD[0][0] = new Rectangle(0, 0, 100, 100);
    }
