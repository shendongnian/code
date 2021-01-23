    private void CreateLabels(int[]Positions1, int[]Positions2, string[] stimulusLabels)
    {
        for (int i = 0; i < Positions1.Length; i++)
        {
            MyLabel label = new Stimulus();
            //All other field inits
            label.Click += myLabel_Click2;
            Controls.Add(label);
        }
    }
