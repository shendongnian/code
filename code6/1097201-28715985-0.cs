        protected void ASPxGridView1_ProcessColumnAutoFilter(object sender,
    DevExpress.Web.ASPxGridViewAutoFilterEventArgs e)
        {
            if (e.Column != ASPxGridView1.Columns["completionDate"]) return;
           if (e.Kind == DevExpress.Web.GridViewAutoFilterEventKind.CreateCriteria)
            {
                // Creates a new filter criterion and applies it.
                e.Criteria = null;
                DateTime yourDate;
                if (!DateTime.TryParse(e.Value, out yourDate)) return;
                yourDate = yourDate.Date;
                DateTime nextDay = yourDate.AddDays(1);
                e.Criteria = (new OperandProperty("completionDate") >= yourDate) & (new OperandProperty("completionDate") < nextDay);
             }
        }
