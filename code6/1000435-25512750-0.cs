    protected void btnAddSkill_Click(object sender, EventArgs e)
    {
        if (ViewState["masterSkills"] != null)
        {
            tblSkillsMaster = (Table) ViewState["masterSkills"];
        }
        else
        {
            plhSkillsTable.Controls.Clear(); //plh is a Placeholder
            tblSkillsMaster = new Table();
            plhSkillsTable.Controls.Add(tblSkillsMaster);
        }
        var row = new TableRow();
        for (int cellNum = 0; cellNum < 3; cellNum++)
        {
            var cell = new TableCell {Text = cellNum.ToString()};
            row.Cells.Add(cell);
        }
        tblSkillsMaster.Rows.Add(row);
        // *** System.Web.UI.WebControls.Table is not serializable ***
        // ViewState["masterSkills"] = tblSkillsMaster;
    }
