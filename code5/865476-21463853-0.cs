    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.KeyData == Keys.Decimal)
            m_DecimalKey = true;
    }
    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        ...
        if (m_DecimalKey || e.KeyChar == CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator)
        {
            // this is a decimal separator
        }
    }
    protected virtual void OnKeyUp(KeyEventArgs e)
    {
        if (e.KeyData == Keys.Decimal)
            m_DecimalKey = false;
    }
