        public class FormA
        {
            private void btnOpenformB_Click(System.Object sender, System.EventArgs e)
            {
                FormB B = new FormB();
                B.OnClosed+=OnFromBClosed; //Add this to handle FromB Closed event
                this.Hide();
                B.Show();
            }
            private void btnExit_Click(System.Object sender, System.EventArgs e)
            {
                this.Close();
            }
            
           //Show FormA again when FromB is closed
            protected override void OnFromBClosed(EventArgs e)
            {
                this.Show();
            }
        
        }
    
    public class FormB
    {
        private void btnReopenA_Click(System.Object sender, System.EventArgs e)
        {
           // FormA A = new FormA(); remove this.
            this.Close();
           // A.Show();  and remove this
        }
    }
