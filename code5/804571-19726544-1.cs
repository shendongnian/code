    private void btnRot_Click(object sender, EventArgs e)
    {
        if (Spielzuege2 >= 16)
        {               
            _Stopwatch2.Stop();
            _ReactionTimes2.Add(_Stopwatch2.Elapsed);
            labelSummary2.Text = String.Format("Player 2: Current: {0:0.000} s Minimum: {1:0.000} s    Maximum: {2:0.000} s", _ReactionTimes2.Last().TotalSeconds, _ReactionTimes2.Min().TotalSeconds, _ReactionTimes2.Max().TotalSeconds);
        }
        else
        {
            _Stopwatch.Stop();
            _ReactionTimes.Add(_Stopwatch.Elapsed);
            labelSummary.Text = String.Format("Player 1: Current: {0:0.000} s    Minimum: {1:0.000} s    Maximum: {2:0.000} s", _ReactionTimes.Last().TotalSeconds, _ReactionTimes.Min().TotalSeconds, _ReactionTimes.Max().TotalSeconds);
        }
    }
