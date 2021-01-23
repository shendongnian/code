    private void dgvVIEW_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e) {
        if (e.SummaryProcess == CustomSummaryProcess.Start) {
          this.sum1 = 0; // <--- class member !
          this.sum2 = 0; // <--- class member !
          return; 
        }
        if (e.SummaryProcess == CustomSummaryProcess.Calculate) {
          if (e.Item.FieldName == "PROMDUGU" {
            this.sum1 += Convert.ToDecimal(e.FieldValue);
            return;
          } 
          if (e.Item.FieldName == "PROMPOTR" {
            this.sum2 += Convert.ToDecimal(e.FieldValue);
            return;
          } 
          return; 
        }
      	if (e.SummaryProcess == CustomSummaryProcess.Finalize && e.Item.FieldName == "customBalance") {
           e.TotalValue = sum1 - sum2;
        }
    } 
