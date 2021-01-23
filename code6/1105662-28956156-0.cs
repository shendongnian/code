    var entriesNotInSubs =
        dt.AsEnumerable().Select(r => r.Field<string>("EXHIBITOR").Trim()).Except(dtSubs.AsEnumerable().Select(r => r.Field<string>("SGMNTID").Trim()));
    var dgvRow_ExhibitorNotInSubs =
        (from exibitors in dgv_Exhibitors.Rows.OfType<DataGridViewRow>()
        select exibitors)
            .Where(j => j.IsNewRow == false)
            .Where(i => entriesNotInSubs.Contains(i.Cells[0].Value.ToString().Trim()));
    foreach (var row in dgvRow_ExhibitorNotInSubs)
    {
        row.Cells[0].Style.BackColor = Color.OrangeRed;
    }
