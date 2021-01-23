     protected void btnBatchId_Click(object sender, EventArgs e) {
          var linkButton = sender as LinkButton;
          if (linkButton != null) {
               var batchId = 0;
               if (int.TryParse(linkButton.CommandArgument, out batchId)) {
                    // batchId variable should contain a valid integer value
               }
          }
     }
