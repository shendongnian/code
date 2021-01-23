    private DateTime m_LastDateTime;
    private void Cld_SelectedDateChanged(object sender, EventArgs e)
    {
        m_LastDateTime = e.Start;
        textBox1.Text = m_LastDateTime.ToString();
        txtHH.Text =m_LastDateTime.Hour.ToString();
        txtMM.Text =m_LastDateTime.Minute.ToString();
    }
    private void btnAddHour_Click( object sender, RoutedEventArgs e )
    {
        m_LastDateTime = m_LastDateTime.AddHours(1);
        txtHH.Text = m_LastDateTime.ToString("HH");
    }
    private void btnAddMinute_Click( object sender, RoutedEventArgs e )
    {
        m_LastDateTime = m_LastDateTime.AddMinutes(1);
        txtMM.Text = m_LastDateTime.ToString( "mm" );
    }
