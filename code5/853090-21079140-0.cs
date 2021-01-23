    public static class ShowResults : Main
    {
        public static void Results(string item, int counterL, int counterS, int counterB, long tick, int miss)
        {
            if (item == "Fbubble")
            {
                loadBubble.Text = counterL.ToString();
                storeBubble.Text = counterS.ToString();
                branchBubble.Text = counterB.ToString();
                ticksBubble.Text = tick.ToString();
                icMissInstrBubble.Text = miss.ToString();
            }
        }
    }
