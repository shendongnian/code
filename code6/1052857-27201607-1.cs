    if (!LabelExist)
    {
        StkPnl_Inputs.Dispatcher.BeginInvoke(new Action(() =>
            {
                CreateLabels(newProjectile);
            }));
    }
