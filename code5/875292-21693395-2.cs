    public Hypothesis getBestHypothesis()
    {
        if (hypotheses.Any())
        {
            Hypothesis H = hypotheses[0];
            foreach (Hypothesis h in hypotheses)
            {
                if (h.confidence >= H.confidence)
                {
                    H = h;
                }
                return H;
            }
        }
        return null;
    }
