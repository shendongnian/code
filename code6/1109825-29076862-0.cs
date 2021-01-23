        internal int _dMisd;
        internal int _dd;
    private void ParametersChanged(object sender, EventArgs e)
    {
    if (AreArgumentsValid() && klasaBetonaComboBox.SelectedItem != null)
    {
        _dMed = Convert.ToDouble(MomentSavijanjaMed.Text);                   
        _dh = Convert.ToDouble(VisinaPresjekaH.Text);
        _db = Convert.ToDouble(SirinaPresjekaB.Text);
        _dd1 = Convert.ToDouble(UdaljenostArmD1.Text);
        _dd = _dh - _dd1;
        _dFck = Convert.ToDouble(fck.Text);
        _gamaC = 1.50;
        gamaCRezultat.Text = _gamaC.ToString();
        dFcd =  _dFck /_gamaC;
        FcdRezultat.Text = dFcd.ToString();
        _dMiSd = _dMed * 1000 / (_dd * _dd * _db * dFcd);
        rezultat.Text = _dMiSd.ToString("F4");
    }
    }
