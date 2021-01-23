    protected void gvTarefas_OnRowCreated(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                InvTarefas tar = e.Row.DataItem as InvTarefas;
                if (tar.EntidadeResponsavel != InvEntidadeResponsavel.PV_PROPRIO)
                {
                    e.Row.Enabled = false;
                    e.Row.CssClass = "PVPortlet_DisabledRoW";
                }
            }
        }
