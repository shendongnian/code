    private void comboBoxCrewMember_SelectedIndexChanged(object sender, EventArgs e)
    {
        string crewMemberName=comboBoxCrewMember.SelectedValue.ToString();
        lblRankValue.Text = crewMemberManager.GetRankName(crewMemberName);
    }
